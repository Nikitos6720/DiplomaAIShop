using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controllers.AI;
using DiplomaAIShop.Models;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

using System.Windows.Forms.DataVisualization.Charting;


namespace DiplomaAIShop.Views.Diagram;

public partial class SellingDiagram : Form
{
    private IMainForm _main;
    private Series _series;

    public SellingDiagram(IMainForm main)
    {
        InitializeComponent();
        _main = main;

        CreateChart();
        panel1.SendToBack();
    }

    private void button1_Click(object sender, EventArgs e) => _main.CloseForm();

    private void CreateChart()
    {
        _series = new()
        {
            ChartType = SeriesChartType.Line,
            Color = Color.FromArgb(245, 143, 1),
            LabelForeColor = Color.FromArgb(245, 143, 1)
        };

        chart.Series.Add(_series);

        GetData(_series);
        GettingPredictions();
    }

    private async void GetData(Series series)
    {
        using var db = new DatabaseController(new());

        await db.Sales
                .Include(x => x.Checks)
                .ThenInclude(x => x.Lines)
                .ThenInclude(x => x.Product)
                .LoadAsync();

        int i = 1;
        foreach (var s in db.Sales.Local)
        {
            chart.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 0.5, i + 0.5, s.Date.ToString("dd.MM.yyyy"), 0, LabelMarkStyle.None));
            _series.Points.AddXY(i, s.TotalAmount);
            _series.Points[i - 1].Label = $"{s.TotalAmount} ₴";
            i++;
        }
    }
    
    private void GettingPredictions()
    {
        using var ant = new AntAlgorithm(7);
        using var per = new Perceptron();
        using var db = new DatabaseController(new());

        double[] inputs = new double[7];

        double antResult, perResult;

        DateTime date = DateTime.Now.AddDays(1);

        var sales = db.Sales
            .Include(x => x.Checks)
            .ThenInclude(x => x.Lines)
            .ThenInclude(x => x.Product)
            .OrderBy(x => x.Date)
            .ToList()
            .TakeLast(7);

        var tomorrow = sales.FirstOrDefault(x => x.Date.Date == date.Date);

        if (tomorrow is null)
        {
            for (int i = 0; i < sales.Count(); i++)
            {
                double amount = (double)sales.ElementAt(i).TotalAmount;
                inputs[7 - sales.Count() + i] = amount;
            }

            antResult = Math.Round(ant.Calculate([.. inputs]), 2);
            perResult = Math.Round(per.Calculate([.. inputs]), 2);

            tomorrow = new()
            {
                AntPrediction = (double.IsNaN(antResult)) ? 0 : (decimal)antResult,
                PerceptronPrediction = (double.IsNaN(perResult)) ? 0 : (decimal)perResult,
                Date = date
            };

            db.Sales.Add(tomorrow);
            db.SaveChanges();
        }

        else
        {
            antResult = (double)tomorrow.AntPrediction;
            perResult = (double)tomorrow.PerceptronPrediction;
        }

        double last = inputs.Last();
        DrawLine();
        DrawAntPred(last, antResult);
        DrawPerPred(last, perResult);
    }

    private void DrawLine()
    {
        int i = chart.ChartAreas[0].AxisX.CustomLabels.Count;
        if (chart.ChartAreas[0].AxisX.CustomLabels.Any(x => x.Text == DateTime.Today.AddDays(1).ToString("dd.MM.yyyy")))
            chart.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 0.5, i + 0.5, DateTime.Today.AddDays(1).ToString("dd.MM.yyyy"), 0, LabelMarkStyle.None));
    }

    private void DrawAntPred(double last, double prediction)
    {
        DrawPrediction(last, prediction, Color.Green);
    }

    private void DrawPerPred(double last, double prediction)
    {
        DrawPrediction(last, prediction, Color.Cyan);
    }

    private void DrawPrediction(double last, double prediction, Color color)
    {
        var series = new Series()
        {
            ChartType = SeriesChartType.Line,
            Color = color,
            LabelForeColor = color
        };

        chart.Series.Add(series);
        int i = chart.ChartAreas[0].AxisX.CustomLabels.Count + 1;
        series.Points.AddXY(i - 3, last);
        series.Points.AddXY(i - 2, prediction);
        series.Points[1].Label = $"{prediction} ₴";
    }
}