using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Extenshions;

public static class FormExtensions
{
    public static void ShowAtPanel(this Form form, Panel panel)
    {
        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;
        form.Show();

        if (form is IListForm l)
            l.LoadsData();

        panel.Controls.Add(form);
    }

    public static void ChangeSize(this Form form) =>
        form.WindowState = (form.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized :
                                                                          FormWindowState.Normal;
}