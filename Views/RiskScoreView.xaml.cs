using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using SWAN.Models;
using SWAN.ViewModels;

namespace SWAN.Views
{
    public partial class RiskScoreView : UserControl
    {
        public PlotModel CyberControlBarGraphModel { get; private set; } = new PlotModel();
        public PlotModel RiskSeverityModel { get; private set; } = new PlotModel();
        public double RiskScore { get; private set; }

        public ObservableCollection<CheckBoxItem> AllControls { get; private set; }

        public RiskScoreView(RMFDashboardViewModel dashboardViewModel)
        {
            InitializeComponent();
            DataContext = this;

            // Bind controls from the dashboard
            AllControls = dashboardViewModel.CheckBoxCollection;

            // Calculate the CVSS risk score
            CVSSCalculator calculator = new CVSSCalculator();
            double attackVector = 0.85;
            double attackComplexity = 0.77;
            double privilegesRequired = 0.62;
            double userInteraction = 0.85;
            double impactConfidentiality = 0.56;
            double impactIntegrity = 0.56;
            double impactAvailability = 0.56;

            RiskScore = calculator.CalculateBaseScore(attackVector, attackComplexity, privilegesRequired, userInteraction, impactConfidentiality, impactIntegrity, impactAvailability);

            // Setup graphs
            SetupCyberControlBarGraph();
            SetupRiskSeverityModel();
        }

        private void SetupCyberControlBarGraph()
        {
            CyberControlBarGraphModel = new PlotModel { Title = "Failed Standards per Cyber Control" };
            var barSeries = new BarSeries
            {
                ItemsSource = new[]
                {
                    new BarItem { Value = 10 },
                    new BarItem { Value = 7 },
                    new BarItem { Value = 8 },
                    new BarItem { Value = 6 }
                },
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };

            CyberControlBarGraphModel.Series.Add(barSeries);
            CyberControlBarGraphModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "CyberControlsAxis",
                ItemsSource = new[] { "Control A", "Control B", "Control C", "Control D" }
            });
        }

        private void SetupRiskSeverityModel()
        {
            RiskSeverityModel = new PlotModel { Title = "Vulnerabilities by Severity" };

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            // Colors for each severity level
            pieSeries.Slices.Add(new PieSlice("Low", 20) { Fill = OxyColors.LightBlue });
            pieSeries.Slices.Add(new PieSlice("Medium", 50) { Fill = OxyColors.Orange });
            pieSeries.Slices.Add(new PieSlice("High", 20) { Fill = OxyColors.Red });
            pieSeries.Slices.Add(new PieSlice("Critical", 10) { IsExploded = true, Fill = OxyColors.DarkRed });

            RiskSeverityModel.Series.Add(pieSeries);
        }
    }

    public class CVSSCalculator
    {
        public double CalculateBaseScore(double attackVector, double attackComplexity, double privilegesRequired, double userInteraction, double impactConfidentiality, double impactIntegrity, double impactAvailability)
        {
            // Calculate Impact
            double impact = 1 - (1 - impactConfidentiality) * (1 - impactIntegrity) * (1 - impactAvailability);

            // Calculate Exploitability
            double exploitability = 8.22 * attackVector * attackComplexity * privilegesRequired * userInteraction;

            // Calculate Impact SubScore
            double impactSubScore = 6.42 * impact;

            // Calculate Base Score
            double baseScore = Math.Min(impactSubScore + exploitability, 10.0);

            // Round up the base score to one decimal place
            baseScore = Math.Ceiling(baseScore * 10) / 10;

            return baseScore;
        }
    }
}
