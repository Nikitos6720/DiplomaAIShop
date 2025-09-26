using System.Text.Json;

namespace DiplomaAIShop.Controllers.AI;

public class AntAlgorithm : IArtificialIntelligence, IDisposable
{
    private readonly int _inputCount;
    private readonly int _antCount;
    private readonly int _iterations;
    private double[,] _pheromones;
    private readonly Random _random;
    private readonly double _evaporation;
    private readonly double _pheromoneBoost;

    public double[] BestWeights { get; private set; }
    public double BestError { get; private set; }

    public AntAlgorithm(int inputCount, int antCount = 20, int iterations = 1000, double evaporation = 0.5, double pheromoneBoost = 1.0)
    {
        _inputCount = inputCount;
        _antCount = antCount;
        _iterations = iterations;
        _evaporation = evaporation;
        _pheromoneBoost = pheromoneBoost;
        _pheromones = new double[_inputCount, 2];
        _random = new Random();

        for (int i = 0; i < _inputCount; i++)
        {
            _pheromones[i, 0] = 1.0;
            _pheromones[i, 1] = 1.0;
        }

        LoadParameters();
    }

    public double Calculate(double[] inputs)
    {
        var max = inputs.Max();
        inputs = inputs.Select(x => x / max).ToArray();

        double result = 0;
        for (int i = 0; i < _inputCount; i++)
            result += inputs[i] * BestWeights[i];
        return result * max;
    }

    public void Train(double[][] inputs, double[] outputs)
    {
        // Находим общий максимум для нормализации
        double maxInput = inputs.SelectMany(x => x).Max();
        double maxOutput = outputs.Max();
        double max = Math.Max(maxInput, maxOutput);

        // Нормализуем входы и выходы
        double[][] normInputs = inputs
            .Select(arr => arr.Select(x => x / max).ToArray())
            .ToArray();
        double[] normOutputs = outputs
            .Select(x => x / max)
            .ToArray();

        // Обучение на батче
        TrainBatch(normInputs, normOutputs);
    }

    private void TrainBatch(double[][] inputs, double[] outputs)
    {
        BestError = double.MaxValue;
        BestWeights = new double[_inputCount];

        for (int iter = 0; iter < _iterations; iter++)
        {
            double[][] antsWeights = new double[_antCount][];
            double[] antsErrors = new double[_antCount];

            for (int ant = 0; ant < _antCount; ant++)
            {
                antsWeights[ant] = new double[_inputCount];
                for (int i = 0; i < _inputCount; i++)
                {
                    double pMinus = _pheromones[i, 0];
                    double pPlus = _pheromones[i, 1];
                    double direction = (_random.NextDouble() < pPlus / (pPlus + pMinus)) ? 1 : -1;
                    antsWeights[ant][i] = Math.Max(-1, Math.Min(1, direction * _random.NextDouble()));
                }
                antsErrors[ant] = CalculateError(antsWeights[ant], inputs, outputs);
            }

            int bestAnt = Array.IndexOf(antsErrors, antsErrors.Min());
            if (antsErrors[bestAnt] < BestError)
            {
                BestError = antsErrors[bestAnt];
                Array.Copy(antsWeights[bestAnt], BestWeights, _inputCount);
            }

            // Испарение феромонов
            for (int i = 0; i < _inputCount; i++)
            {
                _pheromones[i, 0] *= (1 - _evaporation);
                _pheromones[i, 1] *= (1 - _evaporation);
            }

            // Усиление феромонов по лучшему решению
            for (int i = 0; i < _inputCount; i++)
            {
                if (BestWeights[i] > 0)
                    _pheromones[i, 1] += _pheromoneBoost;
                else
                    _pheromones[i, 0] += _pheromoneBoost;
            }
        }
    }

    private double CalculateError(double[] weights, double[][] inputs, double[] outputs)
    {
        double error = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            double predicted = 0;
            for (int j = 0; j < _inputCount; j++)
                predicted += inputs[i][j] * weights[j];
            error += Math.Pow(predicted - outputs[i], 2) + 0.01 * weights.Sum(w => w * w);
        }
        return error / inputs.Length;
    }

    public void SaveParameters(string filePath = "ant_parameters.json")
    {
        var parameters = new AntParameters
        {
            BestWeights = BestWeights,
            Pheromones = ToJaggedArray(_pheromones)
        };

        var json = JsonSerializer.Serialize(parameters);
        File.WriteAllText(filePath, json);
    }

    public void LoadParameters(string filePath = "ant_parameters.json")
    {
        if (!File.Exists(filePath))
            return;

        var json = File.ReadAllText(filePath);
        var parameters = JsonSerializer.Deserialize<AntParameters>(json);
        if (parameters != null)
        {
            BestWeights = parameters.BestWeights;
            _pheromones = ToMatrix(parameters.Pheromones);
        }
    }

    private double[][] ToJaggedArray(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        var result = new double[rows][];
        for (int i = 0; i < rows; i++)
        {
            result[i] = new double[cols];
            for (int j = 0; j < cols; j++)
                result[i][j] = matrix[i, j];
        }
        return result;
    }

    private double[,] ToMatrix(double[][] jagged)
    {
        int rows = jagged.Length;
        int cols = jagged[0].Length;
        var result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = jagged[i][j];
        return result;
    }

    public void Dispose()
    {
        SaveParameters();
    }

    private class AntParameters
    {
        public double[] BestWeights { get; set; }
        public double[][] Pheromones { get; set; }
    }
}