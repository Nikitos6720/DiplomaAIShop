using DiplomaAIShop.Controllers.AI;
using DiplomaAIShop.Extenshions;
using DiplomaAIShop.Views;
using DiplomaAIShop.Views.Diagram;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop;

public partial class Main : Form, IMainForm
{
    private readonly Stack<Form> OpenedForms = [];

    public Main()
    {
        InitializeComponent();
        OpenForm(new General());
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