namespace DiplomaAIShop.Views.General;

public partial class ErrorMessageBox : Form
{
    public ErrorMessageBox(string message)
    {
        InitializeComponent();
        ErrorMessage.Text = message;
    }

    private void button3_Click(object sender, EventArgs e) => Close();
}