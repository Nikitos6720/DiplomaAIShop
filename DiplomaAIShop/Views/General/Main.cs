using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controllers.AI;
using DiplomaAIShop.Extenshions;
using DiplomaAIShop.Views;
using DiplomaAIShop.Views.Diagram;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop;

public partial class Main : Form, IMainForm
{
    // TODO: remove controller after debugging
    private readonly DatabaseController _controller;
    private readonly List<(DateTime Date, double Amount)> salesData;
    private readonly List<double[]> inputsTrain = new();
    private readonly List<double> outputsTrain = new();

    private readonly Stack<Form> OpenedForms = [];

    public Main()
    {
        InitializeComponent();
        OpenForm(new General());

        _controller = new(new());

        // читаем CSV
        var lines = File.ReadAllLines(@"C:\Users\Nikita\OneDrive\Desktop\список данных.csv").ToList();

        // парсим данные: дата + сумма
        salesData = new List<(DateTime Date, double Amount)>();
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (DateTime.TryParse(parts[0], out DateTime date) &&
                double.TryParse(parts[1], out double amount))
            {
                salesData.Add((date, amount));
            }
        }

        int windowSize = 21;
        int totalSamples = 6000;

        for (int i = 0; i < totalSamples; i++)
        {
            if (i + windowSize >= salesData.Count) break;

            // 21 дневное значение прибыли
            double[] lastDays = salesData.Skip(i).Take(windowSize).Select(x => x.Amount).ToArray();

            // агрегаты за этот же период
            double maxVal = lastDays.Max();
            double minVal = lastDays.Min();
            double avgVal = lastDays.Average();

            // формируем итоговый вход (24 признака)
            double[] input = new double[24];
            Array.Copy(lastDays, input, windowSize);
            input[21] = maxVal;
            input[22] = minVal;
            input[23] = avgVal;

            // целевая переменная — значение после окна
            double output = salesData[i + windowSize].Amount;

            inputsTrain.Add(input);
            outputsTrain.Add(output);
        }

        var t1 = new Task(() => TrainAnt());
        var t2 = new Task(() => TrainPerceptron());
        t1.Start();
        t2.Start();

        while (!t1.IsCompleted && !t2.IsCompleted)
        {
            Thread.Sleep(100);
        }

        using AntAlgorithm algorithm = new();
        using Perceptron perceptron = new();

        // проверка на тестовых данных (1000 примеров)
        for (int i = 6000; i < 7000; i++)
        {
            if (i + windowSize >= salesData.Count) break;

            // 21 дневное значение прибыли
            double[] lastDays = salesData.Skip(i).Take(windowSize).Select(x => x.Amount).ToArray();

            // агрегаты за этот период
            double maxVal = lastDays.Max();
            double minVal = lastDays.Min();
            double avgVal = lastDays.Average();

            // итоговый вход (24 признака)
            double[] input = new double[24];
            Array.Copy(lastDays, input, windowSize);
            input[21] = maxVal;
            input[22] = minVal;
            input[23] = avgVal;

            // ожидаемое значение (целевой выход)
            double expected = salesData[i + windowSize].Amount;
            DateTime date = salesData[i + windowSize].Date;

            // прогнозы
            var antP = Math.Round(algorithm.Calculate(input));
            if (double.IsNaN(antP)) antP = 0;

            var perP = Math.Round(perceptron.Calculate(input));
            if (double.IsNaN(perP)) perP = 0;

            // сохраняем результат
            _controller.Sales.Add(new()
            {
                Date = date,
                TotalAmount = (decimal)expected,
                AntPrediction = (decimal)antP,
                PerceptronPrediction = (decimal)perP
            });
        }

        _controller.SaveChanges();
    }

    private void TrainAnt()
    {
        using AntAlgorithm algorithm = new();
        algorithm.Train(inputsTrain.ToArray(), outputsTrain.ToArray());
    }

    private void TrainPerceptron()
    {
        using Perceptron perceptron = new();
        perceptron.Train(inputsTrain.ToArray(), outputsTrain.ToArray());
    }

    #region Events
    private void OpenCategoryList(object sender, EventArgs e) => PressButton(new CategoryList(this), button1);

    private void OpenProductList(object sender, EventArgs e) => PressButton(new ProductList(this), button2);

    private void OpenCheckList(object sender, EventArgs e) => PressButton(new CheckList(this), button3);
    
    private void button10_Click(object sender, EventArgs e) => PressButton(new SellingDiagram(this), button10);

    private void CloseApplication(object sender, EventArgs e) => Application.Exit();

    private void HideApplication(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

    private void ChangeFormState(object sender, EventArgs e) => this.ChangeSize();
    #endregion

    #region Public Methods
    public void CloseForm()
    {
        if (OpenedForms.Count == 0)
            return;

        var openedForm = FormViewer.Controls[0];
        if (openedForm is Form f)
            f.Close();

        FormViewer.Controls.Clear();
        ShowForm(OpenedForms.Pop());

        if (OpenedForms.Count == 1)
            ClearButtons();
    }

    public void OpenForm(Form form)
    {
        if (FormViewer.Controls.Count > 0)
            HideForm(FormViewer.Controls[0]);

        FormViewer.Controls.Clear();
        ShowForm(form);
    }
    #endregion

    #region Private Methods
    private void ClearStack()
    {
        OpenedForms.Clear();
        OpenedForms.Push(new General());
    }

    private void ClearButtons()
    {
        foreach (Control control in MenuPanel.Controls)
            CheckIsButton(control);
    }

    private void HideForm(Control control)
    {
        var openedForm = control;
        if (openedForm is Form f)
        {
            f.Hide();
            OpenedForms.Push(f);
        }
    }

    private void ShowForm(Form form)
    {
        form.ShowAtPanel(FormViewer);
        FormName.Text = $"{form.Tag}";
    }

    private void ChangeButtonColor(Button activeButton)
    {
        ClearButtons();
        activeButton.SetButtonActive();
    }

    private void PressButton(Form form, Button button)
    {
        ClearStack();
        OpenForm(form);
        ChangeButtonColor(button);
    }

    private static void CheckIsButton(Control control)
    {
        if (control is Button button)
            button.SetButtonDeactive();
    }
    #endregion
}