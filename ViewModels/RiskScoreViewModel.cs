using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LiveCharts;
using LiveCharts.Wpf;
using SWAN.Components;
using SWAN.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SWAN.ViewModels
{
    public partial class RiskScoreViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<ConceptualCheckBox> allControls;

        [ObservableProperty]
        public Visibility chartVisibility = Visibility.Hidden;

        public ICommand UpdateRiskCommand => new RelayCommand(UpdateRisk);

        private RMFDashboardViewModel _dash;
        [ObservableProperty]
        public double gaugeValue = 10.0;

        [ObservableProperty]
        private ObservableCollection<ConceptualCheckBox> severitySortedControls;

        [ObservableProperty]
        private ObservableCollection<ConceptualCheckBox> prevalenceSortedControls;
        public SeriesCollection PieChartSeries { get; set; }

        private static readonly Dictionary<int, string> RiskLevelMap = new()
        {
        { 5, "High/High" },
        { 4, "Med/Med" },
        { 3, "Med/Low" },
        { 2, "Low/Med" },
        { 1, "Low/Low" }
        };
        public RiskScoreViewModel( RMFDashboardViewModel dash)
        {
            // Initialize the AllControls collection
            AllControls = new ObservableCollection<ConceptualCheckBox>();
            SeveritySortedControls = new ObservableCollection<ConceptualCheckBox>();
            PrevalenceSortedControls = new ObservableCollection<ConceptualCheckBox>();
            _dash = dash;
            // Listen for the updated controls message
          

            // Initialize the pie chart series
            PieChartSeries = new SeriesCollection();

            // Initially populate the pie chart with the existing data
            UpdatePieChart();
        }
        private void UpdateRisk()
        {
            AllControls = _dash.ConceptualControls;
            ChartVisibility = Visibility.Visible;
            UpdatePieChart();
            UpdateSeveritySortedControls();
            UpdateRiskScore();
            UpdatePrevalenceSortedControls();
            //ShowAllControlsInMessageBox();
        }

        private void UpdatePrevalenceSortedControls()
        {
            // Check if AllControls is null or empty
            if (AllControls == null || !AllControls.Any())
            {
                // Optionally, handle the case where there are no controls to sort
                return;
            }
            var localCopy = AllControls;

            // Assuming 'FailedCount' is a property in ConceptualCheckBox indicating the number of failed checks
            var sortedControls = localCopy
                .Where(control => !control.AllPassed)  // Filter out controls where AllPassed is false
                .OrderByDescending(control => control.FailedCount)  // Sort by FailedCount in descending order
                .ToList();

            // Clear the original collection and add the sorted items
            PrevalenceSortedControls.Clear();
            foreach (var control in sortedControls)
            {
                PrevalenceSortedControls.Add(control);
            }
        }

        private void UpdateRiskScore()
        {
            // Define the risk level map (weight for each severity level)
            var riskLevelWeights = new Dictionary<string, double>
    {
        { "High/High", 10.0 },
        { "Med/Med", 7.0 },
        { "Med/Low", 5.0 },
        { "Low/Med", 3.0 },
        { "Low/Low", 1.0 }
    };

            // Filter out controls that have AllPassed = false
            var localCopy = AllControls;
            var failedControls = localCopy
                .Where(c => !c.AllPassed)
                .ToList();

            // Check if there is any control with High severity
            if (failedControls.Any(c => c.Severity == "High/High"))
            {
                // If any control has High severity, set the risk score to 10
                GaugeValue = 10.0;
                return;
            }

            // Calculate the weighted composite score
            double totalWeight = 0.0;
            int count = 0;

            foreach (var control in failedControls)
            {
                if (riskLevelWeights.TryGetValue(control.Severity, out var weight))
                {
                    totalWeight += weight;
                    count++;
                }
            }

            // If there are controls to consider, compute the average weight
            if (count > 0)
            {
                GaugeValue = Math.Round(totalWeight / count, 1);
            }
            else
            {
                GaugeValue = 0.0;
            }
        }


        public void UpdateSeveritySortedControls()
        {
            // Create a dictionary to map severity strings to their corresponding risk levels
            var riskLevelDictionary = RiskLevelMap.ToDictionary(pair => pair.Value, pair => pair.Key);
            var localCopy = AllControls;
            // Filter out controls where AllPassed is false and sort by severity in descending order
            var sortedControls = localCopy
                .Where(control => !control.AllPassed)  // Filter controls where AllPassed is false
                .OrderByDescending(control => riskLevelDictionary.ContainsKey(control.Severity)
                                               ? riskLevelDictionary[control.Severity]
                                               : 0) // Default to 0 if severity is not found
                .ToList();

            // Clear the original collection and add the sorted items
            SeveritySortedControls.Clear();
            foreach (var control in sortedControls)
            {
                SeveritySortedControls.Add(control);
            }
        }


        private void ShowAllControlsInMessageBox()
        {
            var message = new StringBuilder();

            foreach (var control in SeveritySortedControls)
            {
                message.AppendLine($"Name: {control.Name}, Severity: {control.Severity}, CIA: {control.CIA}, All Passed: {control.AllPassed}");
                foreach (var physicalControl in control.PhysicalControls)
                {
                    message.AppendLine($"\tPhysical Control: {physicalControl.Control}, Passed: {physicalControl.Passed}");
                }
            }

            // Show the message in a MessageBox
            MessageBox.Show(message.ToString(), "All Controls Information");
        }

        private void UpdatePieChart()
        {
            PieChartSeries.Clear();
            var localList = AllControls;
            // Filter ConceptualCheckBoxes where AllPassed is true
            var filteredData = localList
                .Where(c => c is ConceptualCheckBox cb && !cb.AllPassed)
                .Cast<ConceptualCheckBox>()
                .GroupBy(cb => cb.Severity)
                .Select(g => new { Severity = g.Key, Count = g.Count() });

            // Update the pie chart with the new data
            foreach (var data in filteredData)
            {
                PieChartSeries.Add(new PieSeries
                {
                    Title = data.Severity,
                    Values = new ChartValues<int> { data.Count },
                    DataLabels = true
                });
            }
        }

    }
}
