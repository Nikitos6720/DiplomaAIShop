using DiplomaAIShop.Controllers;
using DiplomaAIShop.Models;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

namespace DiplomaAIShop.Views;

public partial class CreateProduct : Form
{
    private IMainForm _main;
    private Product _createdProduct = new();

    public CreateProduct(IMainForm main)
    {
        InitializeComponent();
        _main = main;
        BindData();
    }

    private void button1_Click(object sender, EventArgs e) => _main.CloseForm();

    private void CreateProduct_Load(object sender, EventArgs e) => GetCategories();

    private void button3_Click(object sender, EventArgs e)
    {
        using var db = new DatabaseController(new());

        if (ErrorController.CheckError(textBox1, "Category name must be inputted")) return;
        if (ErrorController.CheckError(comboBox1, "Category must be selected")) return;

        db.Products?.Add(_createdProduct);
        
        db.SaveChanges();
        _main.CloseForm();
    }

    private void BindData()
    {
        textBox1.DataBindings.Add(new("Text", _createdProduct, "Name"));
        richTextBox1.DataBindings.Add(new("Text", _createdProduct, "Description"));
        numericUpDown1.DataBindings.Add(new("Value", _createdProduct, "Count"));
        numericUpDown2.DataBindings.Add(new("Value", _createdProduct, "Price"));
        comboBox1.DataBindings.Add(new("SelectedValue", _createdProduct, "ProductCategoryId"));
    }

    private async void GetCategories()
    {
        using var db = new DatabaseController(new());
        await db.Categories.LoadAsync();

        if (db.Categories is null || !db.Categories.Any())
        {
            new ErrorMessageBox("No categories found. Please create a category first.").ShowDialog();
            _main.OpenForm(new CreateCategory(_main));
        }
        else
        {
            comboBox1.DataSource = db.Categories.Local.ToObservableCollection();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
    }
}