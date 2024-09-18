using OxyPlot;
using SWAN.Components;
using SWAN.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class RiskScoreViewModel : ObservableObject
{
    // Automatically generates the property and OnPropertyChanged invocation for you
    [ObservableProperty]
    private PlotModel cyberControlBarGraphModel;

    [ObservableProperty]
    private PlotModel riskSeverityModel;

    [ObservableProperty]
    private double riskScore;

    // ObservableCollection of all conceptual and physical controls
    [ObservableProperty]
    private ObservableCollection<ConceptualCheckBox> allControls;

    [ObservableProperty]
    private ObservableCollection<PhysicalControl> allPhysicalControls;

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

    public RiskScoreViewModel(RMFDashboardViewModel dashboardViewModel)
    {
        Debug.WriteLine("[DEBUG] RiskScoreViewModel initialized.");
        Debug.WriteLine($"[DEBUG] Dashboard Selected: {dashboardViewModel.SelectedFramework}");

        _dashboardViewModel = dashboardViewModel;

        // Initialize collections
        AllControls = new ObservableCollection<ConceptualCheckBox>();
        AllPhysicalControls = new ObservableCollection<PhysicalControl>(); // Initialize physical controls

        // Polling mechanism for checking when the dashboard is populated
        var timer = new System.Windows.Threading.DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            if (_dashboardViewModel.ConceptualControls != null && _dashboardViewModel.ConceptualControls.Count > 0)
            {
                timer.Stop();
                UpdateControls();
            }
            else
            {
                Debug.WriteLine("[DEBUG] No ConceptualControls found in dashboard view model or dashboard not yet populated.");
            }
        };
        timer.Start();

        // Calculate the CVSS risk score (dummy values for now)
        CVSSCalculator calculator = new CVSSCalculator();
        RiskScore = calculator.CalculateBaseScore(0.85, 0.77, 0.62, 0.85, 0.56, 0.56, 0.56);
    }

    // Method to update both conceptual and physical controls when dashboard is populated
    private void UpdateControls()
    {
        Debug.WriteLine($"[DEBUG] ConceptualControls count in dashboard view model: {_dashboardViewModel.ConceptualControls.Count}");

        // Clear existing controls
        AllControls.Clear();
        AllPhysicalControls.Clear();

        // Sort the conceptual controls by severity
        var sortedControls = _dashboardViewModel.ConceptualControls
            .OrderBy(control => severityOrder.ContainsKey(control.Severity) ? severityOrder[control.Severity] : int.MaxValue)
            .ToList();

        foreach (var conceptualControl in sortedControls)
        {
            Debug.WriteLine($"[DEBUG] Adding conceptual control: {conceptualControl.Name}");
            AllControls.Add(conceptualControl);  // Add conceptual controls

            // Add associated physical controls and filter passed ones
            foreach (var physicalControl in conceptualControl.PhysicalControls)
            {
                if (!physicalControl.Passed) // Only add controls that haven't passed
                {
                    Debug.WriteLine($"[DEBUG] Adding physical control: {physicalControl.Control}");
                    AllPhysicalControls.Add(physicalControl);
                }
            }

            // Check if all physical controls are passed and hide conceptual control if needed
            conceptualControl.IsVisible = conceptualControl.PhysicalControls.All(pc => !pc.Passed);
        }

        Debug.WriteLine($"[DEBUG] AllControls updated. New count: {AllControls.Count}");
        Debug.WriteLine($"[DEBUG] AllPhysicalControls updated. New count: {AllPhysicalControls.Count}");
    }

    // CVSSCalculator class for risk score calculation
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
}
