using DiplomaAIShop.Models;
using DiplomaAIShop.Views;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Controls;

public partial class CheckObject : UserControl
{
    private IMainForm _main;
    private Check _check;

    public CheckObject(IMainForm main, Check check)
    {
        InitializeComponent();
        _main = main;
        _check = check;
        GetData();
    }

    private void GetData()
    {
        CheckId.Text = $"{_check.Id}";
        CheckDate.Text = $"{_check.Date}";
        Price.Text = $"{_check.Price} ₴";
    }

    private void CheckObject_decimalClick(object sender, EventArgs e) => _main.OpenForm(new CheckInfo(_main, _check));
}
