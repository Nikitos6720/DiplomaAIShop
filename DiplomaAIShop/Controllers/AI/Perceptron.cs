using System.Text.Json;

namespace DiplomaAIShop.Controllers.AI;

public class Perceptron : IArtificialIntelligence, IDisposable
{
    private readonly int _inputCount = 24;
    private readonly int _hiddenCount1 = 16;
    private readonly int _hiddenCount2 = 8;
    private readonly int _outputCount = 1;

    private double[,] _weightsInputHidden1;
    private double[,] _weightsHidden1Hidden2;
    private double[,] _weightsHidden2Output;

    private readonly Random _random;
    private readonly double _learningRate;
    private readonly int _epochs;

    public Perceptron(double learningRate = 0.001, int epochs = 500)
    {
        // вход = окно + 4 признака
        _weightsInputHidden1 = new double[_inputCount + 4, _hiddenCount1];
        _weightsHidden1Hidden2 = new double[_hiddenCount1, _hiddenCount2];
        _weightsHidden2Output = new double[_hiddenCount2, _outputCount];

        _random = new Random();
        _learningRate = learningRate;
        _epochs = epochs;

        GetParameters();
    }

    private void GetParameters()
    {
        if (File.Exists("perceptron_parameters.json"))
        {
            var json = File.ReadAllText("perceptron_parameters.json");
            var parameters = JsonSerializer.Deserialize<Dictionary<string, double[][]>>(json);
            if (parameters != null)
            {
                _weightsInputHidden1 = ToMatrix(parameters["WeightsInputHidden1"]);
                _weightsHidden1Hidden2 = ToMatrix(parameters["WeightsHidden1Hidden2"]);
                _weightsHidden2Output = ToMatrix(parameters["WeightsHidden2Output"]);
                return;
            }
        }

        InitWeights(_weightsInputHidden1);
        InitWeights(_weightsHidden1Hidden2);
        InitWeights(_weightsHidden2Output);
    }

    private void InitWeights(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = (_random.NextDouble() - 0.5) * 2;
    }

    public double Calculate(double[] rawWindow)
    {
        double min = rawWindow.Min();
        double max = rawWindow.Max();
        double mean = rawWindow.Average();
        double std = Math.Sqrt(rawWindow.Select(v => (v - mean) * (v - mean)).Average());
        double amp = max / Math.Max(min, 1e-9);
        double vol = std / (mean + 1e-9);
        double trendIndex = 0.5;

        double[] normWindow = rawWindow.Select(v => (v - min) / (max - min + 1e-9)).ToArray();
        double[] features = normWindow
            .Concat(new[] { amp, vol, mean, trendIndex })
            .Select(SafeLog).ToArray();

        double[] hidden1 = ForwardLayer(features, _weightsInputHidden1, useReLU: true);
        double[] hidden2 = ForwardLayer(hidden1, _weightsHidden1Hidden2, useReLU: true);
        double[] output = ForwardLayer(hidden2, _weightsHidden2Output, useReLU: false); // линейный выход

        double logDelta = output[0];
        double lastValue = rawWindow.Last();
        return lastValue * Math.Exp(logDelta);
    }

    public void Train(double[][] inputs, double[] outputs)
    {
        List<double[]> featuresList = new();
        List<double> targets = new();

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

            featuresList.Add(features);
            targets.Add(deltaLog);

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
                    targets.Add(deltaLog);
                }
            }
        }

        for (int epoch = 0; epoch < _epochs; epoch++)
        {
            double totalError = 0;

            for (int sample = 0; sample < featuresList.Count && sample < targets.Count; sample++)
            {
                double[] input = featuresList[sample];
                double expected = targets[sample];

                double[] hidden1 = ForwardLayer(input, _weightsInputHidden1, useReLU: true);
                double[] hidden2 = ForwardLayer(hidden1, _weightsHidden1Hidden2, useReLU: true);
                double[] output = ForwardLayer(hidden2, _weightsHidden2Output, useReLU: false);

                double predicted = output[0];
                double error = expected - predicted;
                totalError += error * error;

                double deltaOutput = error; // линейный выход

                double[] deltaHidden2 = new double[_hiddenCount2];
                for (int j = 0; j < _hiddenCount2; j++)
                {
                    double sum = deltaOutput * _weightsHidden2Output[j, 0];
                    deltaHidden2[j] = sum * (hidden2[j] > 0 ? 1 : 0);
                }

                double[] deltaHidden1 = new double[_hiddenCount1];
                for (int j = 0; j < _hiddenCount1; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < _hiddenCount2; k++)
                        sum += deltaHidden2[k] * _weightsHidden1Hidden2[j, k];
                    deltaHidden1[j] = sum * (hidden1[j] > 0 ? 1 : 0);
                }

                for (int j = 0; j < _hiddenCount2; j++)
                    _weightsHidden2Output[j, 0] += _learningRate * deltaOutput * hidden2[j];

                for (int i = 0; i < _hiddenCount1; i++)
                    for (int j = 0; j < _hiddenCount2; j++)
                        _weightsHidden1Hidden2[i, j] += _learningRate * deltaHidden2[j] * hidden1[i];

                for (int i = 0; i < _weightsInputHidden1.GetLength(0); i++)
                    for (int j = 0; j < _hiddenCount1; j++)
                        _weightsInputHidden1[i, j] += _learningRate * deltaHidden1[j] * input[i];
            }

            if (epoch % 100 == 0)
                Console.WriteLine($"Epoch {epoch}, Error: {totalError / featuresList.Count}");
        }
    }

    private static double[] ForwardLayer(double[] inputs, double[,] weights, bool useReLU)
    {
        double[] outputs = new double[weights.GetLength(1)];
        
        for (int j = 0; j < outputs.Length; j++)
        {
            double sum = 0;
            for (int i = 0; i < inputs.Length; i++)
                sum += inputs[i] * weights[i, j];

            outputs[j] = useReLU ? ReLU(sum) : sum; // линейный выход
        }

        return outputs;
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

    private static double ReLU(double x) => Math.Max(0, x);

    private double SafeLog(double x) => Math.Log(x + 1.0);

    public void Dispose()
    {
        SaveParameters();
        GC.SuppressFinalize(this);
    }

    private void SaveParameters()
    {
        var parameters = new
        {
            WeightsInputHidden1 = ToJaggedArray(_weightsInputHidden1),
            WeightsHidden1Hidden2 = ToJaggedArray(_weightsHidden1Hidden2),
            WeightsHidden2Output = ToJaggedArray(_weightsHidden2Output),
        };

        var json = JsonSerializer.Serialize(parameters);
        File.WriteAllText("perceptron_parameters.json", json);
    }
}