using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Controllers;

public class ErrorController
{
    public static bool CheckError(TextBox box, string message)
    {
        if (string.IsNullOrWhiteSpace(box.Text))
        {
            new ErrorMessageBox(message).ShowDialog();
            box.Focus();
            return true;
        }

        return false;
    }

    public static bool CheckError(ComboBox box, string message)
    {
        if (box.SelectedItem is null)
        {
            new ErrorMessageBox(message).ShowDialog();
            box.Focus();
            return true;
        }

        return false;
    }
}