using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controllers.AI;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

using System.Windows.Forms.DataVisualization.Charting;

namespace DiplomaAIShop.Views.Diagram;

public partial class SellingDiagram : Form
{
    private IMainForm _main;

    private Series _realSeries;
    private Series _perSeries;
    private Series _antSeries;

    public SellingDiagram(IMainForm main)
    {
        InitializeComponent();
        _main = main;

        CreateChart();
        panel1.SendToBack();
    }

    private void button1_Click(object sender, EventArgs e) => _main.CloseForm();

    private void CreateChart()
    {
        chart.Legends.Add(new Legend("MainLegend")
        {
            Docking = Docking.Top,
            Alignment = StringAlignment.Center,
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.WhiteSmoke,
            BackColor = Color.FromArgb(30, 30, 30),
        });

        _realSeries = new Series("Real Price")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.White,
            LabelForeColor = Color.WhiteSmoke,
            Legend = "MainLegend",
            LegendText = "real"
        };

        _perSeries = new Series("Gradient")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.Lime,
            LabelForeColor = Color.Lime,
            Legend = "MainLegend",
            LegendText = "Gradient"
        };

        _antSeries = new Series("Ant algorithm")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.Yellow,
            LabelForeColor = Color.Yellow,
            Legend = "MainLegend",
            LegendText = "Ant algorithm"
        };
        chart.Series.Add(_realSeries);
        chart.Series.Add(_perSeries);
        chart.Series.Add(_antSeries);

        GetData();
    }

    private async void GetData()
    {
        using var db = new DatabaseController(new());

        var sales = db.Sales
                    .OrderBy(x => x.Date)
                    .ToList()
                    .TakeLast(30);

        int i = 1;
        foreach (var s in sales)
        {
            chart.ChartAreas[0].AxisX.CustomLabels.Add(
                new CustomLabel(i - 0.5, i + 0.5, s.Date.ToString("dd.MM.yyyy"), 0, LabelMarkStyle.None)
            );

            _realSeries.Points.AddXY(i, s.TotalAmount);

            if (s.PerceptronPrediction > 0)
            {
                _perSeries.Points.AddXY(i, s.PerceptronPrediction);
            }

            if (s.AntPrediction > 0)
            {
                _antSeries.Points.AddXY(i, s.AntPrediction);
            }

            i++;
        }
    }


    private void GettingPredictions()
    {
        using var ant = new AntAlgorithm(7);
        using var per = new Perceptron();
        using var db = new DatabaseController(new());

        double[] inputs = new double[7];
        double antResult, perResult;

        DateTime date = DateTime.Now.AddDays(1);

        var sales = db.Sales
            .Include(x => x.Checks)
            .ThenInclude(x => x.Lines)
            .ThenInclude(x => x.Product)
            .OrderBy(x => x.Date)
            .ToList()
            .TakeLast(7);

        var tomorrow = sales.FirstOrDefault(x => x.Date.Date == date.Date);

        if (tomorrow is null)
        {
            for (int j = 0; j < sales.Count(); j++)
            {
                double amount = (double)sales.ElementAt(j).TotalAmount;
                inputs[7 - sales.Count() + j] = amount;
            }

            antResult = Math.Round(ant.Calculate([.. inputs]), 2);
            perResult = Math.Round(per.Calculate([.. inputs]), 2);

            tomorrow = new()
            {
                AntPrediction = (double.IsNaN(antResult)) ? 0 : (decimal)antResult,
                PerceptronPrediction = (double.IsNaN(perResult)) ? 0 : (decimal)perResult,
                Date = date
            };

            db.Sales.Add(tomorrow);
            db.SaveChanges();
        }
        else
        {
            antResult = (double)tomorrow.AntPrediction;
            perResult = (double)tomorrow.PerceptronPrediction;
        }

        double last = inputs.Last();
        int i = chart.ChartAreas[0].AxisX.CustomLabels.Count + 1;

        chart.ChartAreas[0].AxisX.CustomLabels.Add(
            new CustomLabel(i - 0.5, i + 0.5, date.ToString("dd.MM.yyyy"), 0, LabelMarkStyle.None)
        );

        // Добавляем точки для персептрона
        _perSeries.Points.AddXY(i - 1, last);
        _perSeries.Points.AddXY(i, perResult);
        _perSeries.Points[^1].Label = $"{perResult} ₴";

        // Добавляем точки для муравьёв
        _antSeries.Points.AddXY(i - 1, last);
        _antSeries.Points.AddXY(i, antResult);
        _antSeries.Points[^1].Label = $"{antResult} ₴";
    }
}