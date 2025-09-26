using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controls;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

using System.Collections.Frozen;

namespace DiplomaAIShop.Views;

public partial class CategoryList : Form, IListForm
{
    private IMainForm _main;

    public CategoryList(IMainForm main)
    {
        InitializeComponent();
        _main = main;
        LoadCategories();
    }

    private void button1_Click(object sender, EventArgs e) => _main.CloseForm();

    private void button3_Click(object sender, EventArgs e)
    {
        _main.OpenForm(new CreateCategory(_main));
        LoadCategories();
    }

    public void LoadsData() => LoadCategories();

    private async void LoadCategories()
    {
        using var db = new DatabaseController(new());

        flowLayoutPanel1.Controls.Clear();

        await foreach (var category in db.Categories.Include(x => x.Products).AsAsyncEnumerable())
        {
            var categoryInfo = new CategoryObject(_main, category);
            flowLayoutPanel1.Controls.Add(categoryInfo);
        }
    }
}