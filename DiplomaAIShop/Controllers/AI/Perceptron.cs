using System.Text.Json;

namespace DiplomaAIShop.Controllers.AI;

public class Perceptron : IArtificialIntelligence, IDisposable
{
    private readonly int _inputCount;
    private readonly int _hiddenCount;
    private readonly int _outputCount;

    private double[,] _weightsInputHidden;
    private double[,] _weightsHiddenOutput;
    private readonly Random _random;
    private readonly double _learningRate;
    private readonly int _epoch;

    public Perceptron()
    {
        _inputCount = 7;
        _hiddenCount = 3;
        _outputCount = 1;

        _weightsInputHidden = new double[_inputCount, _hiddenCount];
        _weightsHiddenOutput = new double[_hiddenCount, _outputCount];
        _random = new Random();
        _learningRate = 0.05;
        _epoch = 1000;

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
                _weightsInputHidden = ToMatrix(parameters["WeightsInputHidden"]);
                _weightsHiddenOutput = ToMatrix(parameters["WeightsHiddenOutput"]);
            }
        }

        else
        {
            for (int i = 0; i < _weightsInputHidden.GetLength(0); i++)
                for (int j = 0; j < _weightsInputHidden.GetLength(1); j++)
                    _weightsInputHidden[i, j] = _random.NextDouble() * 2 - 1;

            for (int i = 0; i < _weightsHiddenOutput.GetLength(0); i++)
                for (int j = 0; j < _weightsHiddenOutput.GetLength(1); j++)
                    _weightsHiddenOutput[i, j] = _random.NextDouble() * 2 - 1;
        }
    }

    public double Calculate(double[] inputs)
    {
        double max = inputs.Max();

        for (int i = 0; i < inputs.Length; i++)
            inputs[i] /= max;

        // Forward pass
        double[] firstHidden = new double[_hiddenCount];
        for (int j = 0; j < _hiddenCount; j++)
        {
            double sum = 0;
            for (int i = 0; i < _inputCount; i++)
                sum += inputs[i] * _weightsInputHidden[i, j];
            firstHidden[j] = Sigmoid(sum);
        }

        double output = 0;
        for (int i = 0; i < _hiddenCount; i++)
            output += firstHidden[i] * _weightsHiddenOutput[i, 0];
        output = Sigmoid(output);

        return output * max;
    }

    public void Train(double[][] inputs, double[] outputs)
    {
        double maxInput = inputs.SelectMany(x => x).Max();
        double maxOutput = outputs.Max();
        double max = Math.Max(maxInput, maxOutput);

        double[][] normInputs = inputs
            .Select(arr => arr.Select(x => x / max).ToArray())
            .ToArray();

        double[] normOutputs = outputs
            .Select(x => x / max)
            .ToArray();

        for (int epoch = 0; epoch < _epoch; epoch++)
        {
            for (int sample = 0; sample < normInputs.Length; sample++)
            {
                double[] input = normInputs[sample];
                double expected = normOutputs[sample];

                double[] firstHidden = new double[_hiddenCount];
                for (int j = 0; j < _hiddenCount; j++)
                {
                    double sum = 0;
                    for (int i = 0; i < _inputCount; i++)
                        sum += input[i] * _weightsInputHidden[i, j];
                    firstHidden[j] = Sigmoid(sum);
                }

                double output = 0;
                for (int i = 0; i < _hiddenCount; i++)
                    output += firstHidden[i] * _weightsHiddenOutput[i, 0];
                output = Sigmoid(output);

                double deltaOutput = (expected - output) * output * (1 - output);

                double[] deltaFirstHidden = new double[_hiddenCount];
                for (int i = 0; i < _hiddenCount; i++)
                {
                    double sum = deltaOutput * _weightsHiddenOutput[i, 0];
                    deltaFirstHidden[i] = sum * firstHidden[i] * (1 - firstHidden[i]);
                }

                for (int i = 0; i < _hiddenCount; i++)
                    _weightsHiddenOutput[i, 0] += _learningRate * deltaOutput * firstHidden[i];

                for (int i = 0; i < _inputCount; i++)
                    for (int j = 0; j < _hiddenCount; j++)
                        _weightsInputHidden[i, j] += _learningRate * deltaFirstHidden[j] * input[i];
            }
        }
    }

    public void Dispose()
    {
        // Сериализация весов в файл (пример для двумерных массивов)
        var parameters = new
        {
            WeightsInputHidden = ToJaggedArray(_weightsInputHidden),
            WeightsHiddenOutput = ToJaggedArray(_weightsHiddenOutput),
        };

        var json = JsonSerializer.Serialize(parameters);
        File.WriteAllText("perceptron_parameters.json", json);
    }

    private double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

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