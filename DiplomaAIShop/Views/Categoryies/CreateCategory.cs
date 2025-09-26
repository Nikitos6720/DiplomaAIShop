using DiplomaAIShop.Controllers;
using DiplomaAIShop.Models;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Views;

public partial class CreateCategory : Form
{
    private IMainForm _main;
    private ProductCategory _category = new();

    public CreateCategory(IMainForm main)
    {
        InitializeComponent();
        _main = main;
        BindData();
    }

    private void button1_Click(object sender, EventArgs e) => _main.CloseForm();

    private void button3_Click(object sender, EventArgs e)
    {
        using var db = new DatabaseController(new());

        if (ErrorController.CheckError(textBox1, "Category name must be inputted"))
            return;

        db.Categories?.Add(_category);
        db.SaveChanges();
        _main.CloseForm();
    }

    private void BindData()
    {
        textBox1.DataBindings.Add(new("Text", _category, "Name"));
        richTextBox1.DataBindings.Add(new("Text", _category, "Description"));
    }
}