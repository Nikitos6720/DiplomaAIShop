using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaAIShop.Models;

public class SellsHistory
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Column("Summary")]
    public decimal TotalAmount { get; set; }

    public decimal AntPrediction { get; set; }

    public decimal PerceptronPrediction { get; set; }

    public ICollection<Check> Checks { get; set; } = [];
}