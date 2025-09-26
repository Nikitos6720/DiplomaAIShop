using DiplomaAIShop.Models;
using DiplomaAIShop.Views;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Controls;

public partial class CategoryObject : UserControl
{
    private IMainForm _main;
    private ProductCategory _category;

    public CategoryObject(IMainForm main, ProductCategory category)
    {
        InitializeComponent();
        _main = main;
        _category = category;
        CategoryName.Text = _category.Name;
    }

    private void OpenCategoryInformation(object sender, MouseEventArgs e)
    {
        _main.OpenForm(new CategoryInfo(_main, _category));
    }
}