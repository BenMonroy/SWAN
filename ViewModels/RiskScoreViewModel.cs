using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using SWAN.Views;
using SWAN.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SWAN.Components;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace SWAN.ViewModels
{
    public partial class RiskScoreViewModel : UserControl
    {
        public PlotModel CyberControlBarGraphModel { get; private set; }
        public PlotModel RiskSeverityModel { get; private set; }
        public double RiskScore { get; private set; }

        // ObservableCollection of all conceptual controls
        public ObservableCollection<ConceptualCheckBox> AllControls { get; private set; }

        private RMFDashboardViewModel _dashboardViewModel;

        // Severity levels for sorting
        private readonly Dictionary<string, int> severityOrder = new Dictionary<string, int>
        {
            { "High/High", 1 },
            { "High/Med", 2 },
            { "Med/Med", 3 },
            { "Med/Low", 4 },
            { "Low/Low", 5 }
        };

        // Receives RMFDashboardViewModel and subscribes to property change events
        public RiskScoreViewModel(RMFDashboardViewModel dashboardViewModel)
        {
            DataContext = this;

            // Initialize AllControls as an empty collection
            AllControls = new ObservableCollection<ConceptualCheckBox>();
            _dashboardViewModel = dashboardViewModel;

            // Subscribe to the OnControlsPopulated event
            _dashboardViewModel.OnControlsPopulated += UpdateControls;

            // Calculate the CVSS risk score (dummy values for now)
            CVSSCalculator calculator = new CVSSCalculator();
            RiskScore = calculator.CalculateBaseScore(0.85, 0.77, 0.62, 0.85, 0.56, 0.56, 0.56);

            // Setup graphs
            SetupCyberControlBarGraph();
            SetupRiskSeverityModel();
        }

        // Method to manually update AllControls when ConceptualControls are populated and sort them by severity
        public void UpdateControls()
        {
            // Clear existing controls
            AllControls.Clear();  

            // Sort the conceptual controls by severity
            var sortedControls = _dashboardViewModel.ConceptualControls
                .OrderBy(control => severityOrder.ContainsKey(control.Severity) ? severityOrder[control.Severity] : int.MaxValue)
                .ToList();

            foreach (var control in sortedControls)
            {
                AllControls.Add(control);
            }
            // Notify the UI about changed controls
            OnPropertyChanged(nameof(AllControls));
        }

        // CVSSCalculator class for risk score calculation, will be changed
        public class CVSSCalculator
        {
            public double CalculateBaseScore(double attackVector, double attackComplexity, double privilegesRequired, double userInteraction, double impactConfidentiality, double impactIntegrity, double impactAvailability)
            {
                double impact = 1 - (1 - impactConfidentiality) * (1 - impactIntegrity) * (1 - impactAvailability);
                double exploitability = 8.22 * attackVector * attackComplexity * privilegesRequired * userInteraction;
                double impactSubScore = 6.42 * impact;
                double baseScore = Math.Min(impactSubScore + exploitability, 10.0);
                return Math.Ceiling(baseScore * 10) / 10;
            }
        }

        // Sets up the bar graph for cyber controls
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

        // Sets up the pie chart for risk severity
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

            // Adding slices for severity levels
            pieSeries.Slices.Add(new PieSlice("Low", 20) { Fill = OxyColors.LightBlue });
            pieSeries.Slices.Add(new PieSlice("Medium", 50) { Fill = OxyColors.Orange });
            pieSeries.Slices.Add(new PieSlice("High", 20) { Fill = OxyColors.Red });
            pieSeries.Slices.Add(new PieSlice("Critical", 10) { IsExploded = true, Fill = OxyColors.DarkRed });

            RiskSeverityModel.Series.Add(pieSeries);
        }

        // Notify property changed if needed
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
