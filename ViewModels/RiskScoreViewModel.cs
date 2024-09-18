using OxyPlot;
using SWAN.Components;
using SWAN.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;

public partial class RiskScoreViewModel : UserControl
{
    public PlotModel CyberControlBarGraphModel { get; private set; }
    public PlotModel RiskSeverityModel { get; private set; }
    public double RiskScore { get; private set; }

    public ObservableCollection<ConceptualCheckBox> AllControls { get; private set; }
    public ObservableCollection<PhysicalControl> AllPhysicalControls { get; private set; }

    private RMFDashboardViewModel _dashboardViewModel;

    // Dictionary to sort by severity
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

        DataContext = this;

        AllControls = new ObservableCollection<ConceptualCheckBox>();
        AllPhysicalControls = new ObservableCollection<PhysicalControl>();

        _dashboardViewModel = dashboardViewModel;

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

        CVSSCalculator calculator = new CVSSCalculator();
        RiskScore = calculator.CalculateBaseScore(0.85, 0.77, 0.62, 0.85, 0.56, 0.56, 0.56);
    }

    // Method to update both conceptual and physical controls when dashboard is populated
    public void UpdateControls()
    {
        Debug.WriteLine($"[DEBUG] ConceptualControls count in dashboard view model: {_dashboardViewModel.ConceptualControls.Count}");

        AllControls.Clear();
        AllPhysicalControls.Clear();

        // Sort conceptual controls by severity using the dictionary
        var sortedControls = _dashboardViewModel.ConceptualControls
            .OrderBy(control => severityOrder.ContainsKey(control.Severity) ? severityOrder[control.Severity] : int.MaxValue)
            .ToList();

        foreach (var conceptualControl in sortedControls)
        {
            Debug.WriteLine($"[DEBUG] Adding conceptual control: {conceptualControl.Name}");
            AllControls.Add(conceptualControl);

            // Add associated physical controls
            foreach (var physicalControl in conceptualControl.PhysicalControls)
            {
                Debug.WriteLine($"[DEBUG] Adding physical control: {physicalControl.Control}");
                AllPhysicalControls.Add(physicalControl);
            }
        }

        Debug.WriteLine($"[DEBUG] AllControls updated. New count: {AllControls.Count}");
        Debug.WriteLine($"[DEBUG] AllPhysicalControls updated. New count: {AllPhysicalControls.Count}");

        OnPropertyChanged(nameof(AllControls));
        OnPropertyChanged(nameof(AllPhysicalControls));
    }

    // CVSSCalculator class for risk score calculation, need to edit
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

    protected void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
