using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaAIShop.Models;

public class Check
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public bool IsClosed { get; set; }

    public decimal Price => Lines.Sum(line => line.Price);

    public int? SellsHistoryId { get; set; }

    public virtual ICollection<CheckLine>? Lines { get; set; } = [];

    [ForeignKey("SellsHistoryId")]
    public virtual SellsHistory? History { get; set; }
}