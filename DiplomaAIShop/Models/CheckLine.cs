using DiplomaAIShop.Views.General;

using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaAIShop.Models;

public class CheckLine
{
    private int _id;

    public int Id
    {
        get => _id;
        set => _id = value;
    }
    
    public int CheckId { get; set; }
    
    public int ProductId { get; set; }

    public uint Count { get; set; }

    public decimal Price => Count * Product.Price;

    [ForeignKey("CheckId")]
    public virtual Check? Check { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }

    public bool Calculates()
    {
        if (Count - Product.Count < 0)
            throw new ArgumentException($"Cannot add more items than available in stock (Product: {Product.Name}).");

        if (Count <= 0)
            throw new ArgumentException("Count must be greater than zero.");

        if (Check == null)
            throw new InvalidOperationException("Check cannot be null.");

        return true;
    }
}