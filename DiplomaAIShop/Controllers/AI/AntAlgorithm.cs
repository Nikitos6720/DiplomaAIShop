using System.Text.Json;

namespace DiplomaAIShop.Controllers.AI;

public class AntAlgorithm : IArtificialIntelligence, IDisposable
{
    private readonly int _inputCount = 24;
    private readonly int[] _hiddenLayers = { 16, 8 };
    private readonly int _outputCount = 1;

    private readonly int _antCount;
    private readonly int _iterations;
    private readonly double _evaporation;
    private readonly double _pheromoneBoost;
    private readonly Random _random;
    private int _iter;

    private double[][,] _pheromones;

    public double[][,] BestWeights { get; private set; }
    
    public double BestError { get; private set; }

    public AntAlgorithm(int antCount = 20, int iterations = 100, double evaporation = 0.5, double pheromoneBoost = 1.0)
    {
        _antCount = antCount;
        _iterations = iterations;
        _evaporation = evaporation;
        _pheromoneBoost = pheromoneBoost;
        _random = new Random();

        InitPheromones();
        LoadParameters();
    }

    private void InitPheromones()
    {
        // слои формируются из: окно (28) + 4 признака, затем скрытые, затем выход
        int augmentedInput = _inputCount + 4; // amp, vol, mean, trendIndex
        int[] layers = new int[] { augmentedInput }.Concat(_hiddenLayers).Concat(new[] { _outputCount }).ToArray();

        _pheromones = new double[layers.Length - 1][,];
        BestWeights = new double[layers.Length - 1][,];

        for (int l = 0; l < layers.Length - 1; l++)
        {
            _pheromones[l] = new double[layers[l], layers[l + 1]];
            BestWeights[l] = new double[layers[l], layers[l + 1]];
            for (int i = 0; i < layers[l]; i++)
                for (int j = 0; j < layers[l + 1]; j++)
                    _pheromones[l][i, j] = 1.0;
        }
    }

    // безопасные функции
    private double SafeLog(double x) => Math.Log(x + 1e-9);

    public double Calculate(double[] rawWindow)
    {
        // признаки окна
        double min = rawWindow.Min();
        double max = rawWindow.Max();
        double mean = rawWindow.Average();
        double std = Math.Sqrt(rawWindow.Select(v => (v - mean) * (v - mean)).Average());
        double amp = max / Math.Max(min, 1e-9);
        double vol = std / (mean + 1e-9);
        double trendIndex = 0.5;

        // нормализация и фичи
        double[] normWindow = rawWindow.Select(v => (v - min) / (max - min + 1e-9)).ToArray();
        double[] features = normWindow
            .Concat([amp, vol, mean, trendIndex])
            .Select(SafeLog).ToArray();

        // прямой проход
        double[] layer = features;
        for (int l = 0; l < BestWeights.Length; l++)
        {
            double[] next = new double[BestWeights[l].GetLength(1)];
            for (int j = 0; j < next.Length; j++)
            {
                double sum = 0;
                for (int i = 0; i < layer.Length; i++)
                    sum += layer[i] * BestWeights[l][i, j];
                bool isLast = (l == BestWeights.Length - 1);
                next[j] = double.IsNaN(sum) ? 0 : (isLast ? Math.Tanh(sum) : Sigmoid(sum));
            }
            layer = next;
        }

        double logDelta = layer[0] * 2.0;
        double logYt = SafeLog(rawWindow.Last());
        double logYt1 = logYt + logDelta;
        return Math.Exp(logYt1) * 0.2;
    }

    public void Train(double[][] inputs, double[] outputs)
    {
        List<double[]> featuresList = new();
        List<double> scaledTargets = new();
        List<double> rawDeltas = new();

        // 1. Собираем признаки и сырые deltaLog
        for (int i = 0; i < inputs.Length - 1; i++)
        {
            var window = inputs[i];
            double y_t = outputs[i];
            double y_t1 = outputs[i + 1];

            double min = window.Min();
            double max = window.Max();
            double mean = window.Average();
            double std = Math.Sqrt(window.Select(v => (v - mean) * (v - mean)).Average());
            double amp = max / Math.Max(min, 1e-9);
            double vol = std / (mean + 1e-9);
            double trendIndex = i / (double)(inputs.Length - 1);

            double[] normWindow = window.Select(v => (v - min) / (max - min + 1e-9)).ToArray();
            double[] features = normWindow
                .Concat(new[] { amp, vol, mean, trendIndex })
                .Select(SafeLog).ToArray();

            double deltaLog = SafeLog(y_t1) - SafeLog(y_t);
            rawDeltas.Add(deltaLog);
            featuresList.Add(features);
        }

        // 2. Вычисляем масштаб по абсолютным deltaLog
        double maxDelta = rawDeltas.Select(Math.Abs).Max();

        // 3. Масштабируем и добавляем цели
        for (int i = 0; i < rawDeltas.Count; i++)
        {
            double scaledDelta = Math.Tanh(rawDeltas[i] / maxDelta);
            scaledTargets.Add(scaledDelta);
        }

        // 4. Аугментация всплесков
        for (int i = 0; i < inputs.Length - 1; i++)
        {
            var window = inputs[i];
            double min = window.Min();
            double max = window.Max();
            double mean = window.Average();
            double std = Math.Sqrt(window.Select(v => (v - mean) * (v - mean)).Average());
            double amp = max / Math.Max(min, 1e-9);
            double vol = std / (mean + 1e-9);
            double trendIndex = i / (double)(inputs.Length - 1);

            if (amp > 1.5 || vol > 0.2)
            {
                for (int k = 0; k < 3; k++)
                {
                    double scale = 1.0 + 0.05 * k;
                    double noise = 0.01;
                    var aug = window.Select(v => v * scale + (_random.NextDouble() - 0.5) * noise).ToArray();

                    var normAug = aug.Select(v => (v - min) / (max - min + 1e-9)).ToArray();
                    var augFeatures = normAug
                        .Concat(new[] { amp, vol, mean, trendIndex })
                        .Select(SafeLog).ToArray();

                    featuresList.Add(augFeatures);
                    scaledTargets.Add(Math.Tanh(rawDeltas[i] / maxDelta)); // тот же deltaLog
                }
            }
        }

        // 5. Обучение
        BestError = double.MaxValue;

        for (_iter = 0; _iter < _iterations; _iter++)
        {
            var antsWeights = new List<double[][,]>();
            var antsErrors = new List<double>();

            for (int ant = 0; ant < _antCount; ant++)
            {
                var weights = GenerateWeights();
                double error = CalculateError(weights, featuresList.ToArray(), scaledTargets.ToArray());
                antsWeights.Add(weights);
                antsErrors.Add(error);
            }

            int bestAnt = antsErrors.IndexOf(antsErrors.Min());
            if (antsErrors[bestAnt] < BestError)
            {
                BestError = antsErrors[bestAnt];
                BestWeights = antsWeights[bestAnt];
            }

            UpdatePheromones(BestWeights);
        }
    }

    private double[][,] GenerateWeights()
    {
        var weights = new double[_pheromones.Length][,];
        for (int l = 0; l < _pheromones.Length; l++)
        {
            int rows = _pheromones[l].GetLength(0);
            int cols = _pheromones[l].GetLength(1);
            weights[l] = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    var mu = _pheromones[l][i, j];
                    var sigma = GetSigma();
                    weights[l][i, j] = mu + sigma * ( _random.NextDouble() * 2 - 1 );
                }
        }
        return weights;
    }

    private double GetSigma()
    {
        double startSigma = 1.0;
        double endSigma = 0.1;
        double progress = _iter / (double)_iterations;
        return startSigma * (1.0 - progress) + endSigma * progress;
    }

    private double CalculateError(double[][,] weights, double[][] inputs, double[] outputs)
    {
        double error = 0;
        int n = Math.Min(inputs.Length, outputs.Length);
        for (int k = 0; k < n; k++)
        {
            double predicted = Forward(inputs[k], weights);
            double penalty = Math.Abs(predicted);
            error += Math.Abs(predicted - outputs[k]) + 0.1 * penalty;
        }
        return error / Math.Max(1, n);
    }

    private double Forward(double[] inputs, double[][,] weights)
    {
        double[] layer = inputs;
        for (int l = 0; l < weights.Length; l++)
        {
            double[] next = new double[weights[l].GetLength(1)];
            for (int j = 0; j < next.Length; j++)
            {
                double sum = 0;
                for (int i = 0; i < layer.Length; i++)
                    sum += layer[i] * weights[l][i, j];
                bool isLast = (l == weights.Length - 1);
                next[j] = double.IsNaN(sum) ? 0 : (isLast ? sum : Sigmoid(sum));
            }
            layer = next;
        }
        return layer[0];
    }

    private void UpdatePheromones(double[][,] bestWeights)
    {
        for (int l = 0; l < _pheromones.Length; l++)
        {
            int rows = _pheromones[l].GetLength(0);
            int cols = _pheromones[l].GetLength(1);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    _pheromones[l][i, j] *= (1 - _evaporation);
                    _pheromones[l][i, j] += _pheromoneBoost * Math.Abs(bestWeights[l][i, j]);
                }
        }
    }

    private double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));

    public void Dispose() => SaveParameters();

    public void SaveParameters(string filePath = "ant_nn.json")
    {
        if (BestWeights == null) return;

        var jaggedWeights = BestWeights
            .Select(matrix => ToJaggedArray(matrix))
            .ToArray();

        var json = JsonSerializer.Serialize(jaggedWeights);
        File.WriteAllText(filePath, json);
    }

    public void LoadParameters(string filePath = "ant_nn.json")
    {
        if (!File.Exists(filePath)) return;

        var json = File.ReadAllText(filePath);
        var jaggedWeights = JsonSerializer.Deserialize<double[][][]>(json);

        if (jaggedWeights != null)
        {
            BestWeights = jaggedWeights
                .Select(j => ToMatrix(j))
                .ToArray();
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
}