using DiplomaAIShop.Controllers;
using DiplomaAIShop.Models;

using Microsoft.EntityFrameworkCore;

namespace DiplomaAIShop.Controls;

public partial class ProductObject : UserControl
{
    private Product _product;

    public ProductObject(Product product)
    {
        InitializeComponent();
        _product = product;
        ProductName.Text = _product.Name;
        ProductCategory.Text = _product.ProductCategory?.Name;
        ProductPrice.Text = $"{_product.Price} ₴";
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        using var db = new DatabaseController(new());
        var check = db.Checks.Include(x => x.Lines).ThenInclude(x => x.Product).FirstOrDefault(x => !x.IsClosed);

        if (check is null)
        {
            check = new();
            db.Checks.Add(check);
            await db.SaveChangesAsync();
        }

        if (check.Lines.Any(x => x.ProductId == _product.Id))
        {
            var line = check.Lines.First(x => x.ProductId == _product.Id);
            line.Count += 1;

            db.Update(line);
        }

        else
        {
            var checkLine = new CheckLine()
            {
                ProductId = _product.Id,
                CheckId = check.Id,
                Count = 1
            };

            db.Lines.Add(checkLine);
        }

        await db.SaveChangesAsync();
    }
}