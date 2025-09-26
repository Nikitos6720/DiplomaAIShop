namespace DiplomaAIShop.Controllers.AI;

public interface IArtificialIntelligence
{
    public double Calculate(double[] inputs);
    public void Train(double[][] inputs, double[] outputs);
}