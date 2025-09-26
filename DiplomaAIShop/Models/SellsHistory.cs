namespace DiplomaAIShop.Models;

public class SellsHistory
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal TotalAmount => Checks.Sum(x => x.Price);

    public decimal AntPrediction { get; set; }

    public decimal PerceptronPrediction { get; set; }

    public ICollection<Check> Checks { get; set; } = [];
}