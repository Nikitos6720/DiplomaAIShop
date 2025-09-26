using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controls;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

namespace DiplomaAIShop.Views;

public partial class ProductList : Form, IListForm
{
    private IMainForm _main;

    public ProductList(IMainForm main)
    {
        InitializeComponent();
        _main = main;
    }

    public void LoadsData()
    {
        LoadProducts();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _main.CloseForm();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        _main.OpenForm(new CreateProduct(_main));
        LoadProducts();
    }

    private async void LoadProducts()
    {
        using var db = new DatabaseController(new());

        flowLayoutPanel1.Controls.Clear();
        await foreach (var product in db.Products.Include(x => x.ProductCategory).AsAsyncEnumerable())
        {
            var productInfo = new ProductObject(product);
            flowLayoutPanel1.Controls.Add(productInfo);
        }
    }
}