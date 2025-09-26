namespace DiplomaAIShop.Models;

public class ProductCategory
{
    private int _id;
    private string _name = string.Empty;
    private string _description = string.Empty;

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

    public virtual ICollection<Product>? Products { get; set; } = [];
}