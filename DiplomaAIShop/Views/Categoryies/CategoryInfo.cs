using DiplomaAIShop.Models;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Views;

public partial class CategoryInfo : Form
{
    private IMainForm _main;
    private ProductCategory _category;

    public CategoryInfo(IMainForm main, ProductCategory category)
    {
        InitializeComponent();
        _main = main;
        _category = category;
        LoadData();
    }

    private void button1_Click(object sender, EventArgs e) => _main.CloseForm();

    private void LoadData()
    {
        CategoryName.DataBindings.Add(new("Text", _category, "Name"));
        CategoryDescription.DataBindings.Add(new("Text", _category, "Description"));

        foreach (var product in _category.Products ?? [])
        {
            var productObject = new Controls.ProductObject(product);
            flowLayoutPanel1.Controls.Add(productObject);
        }
    }
}