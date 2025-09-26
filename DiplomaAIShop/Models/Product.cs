using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaAIShop.Models;

public class Product : Removable
{
    private int _id;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private decimal _price;
    private uint _count;
    private int _productCategoryId;
    private bool _isActive = true;

    [Key]
    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public decimal Price
    {
        get => _price;
        set => _price = value;
    }

    public uint Count
    {
        get => _count;
        set => _count = value;
    }

    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }

    public int ProductCategoryId
    {
        get => _productCategoryId;
        set => _productCategoryId = value;
    }

    [ForeignKey("ProductCategoryId")]
    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<CheckLine>? Sales { get; set; } = [];

    public void Remove()
    {
        if (!_isActive)
            throw new InvalidOperationException("Product is already inactive.");
        _isActive = false;
    }
}