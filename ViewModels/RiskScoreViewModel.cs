using OxyPlot;
using OxyPlot.Series;
using SWAN.Components;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using OxyPlot.Axes;
using SWAN.ViewModels;

public partial class RiskScoreViewModel : ObservableObject
{
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

    // Severity levels for sorting and risk calculation
    private readonly Dictionary<string, int> severityOrder = new Dictionary<string, int>
    {
        { "High/High", 1 },
        { "High/Med", 2 },
        { "Med/Med", 3 },
        { "Med/Low", 4 },
        { "Low/Med", 5 },
        { "Low/Low", 6 }
    };

    public RiskScoreViewModel(RMFDashboardViewModel dashboardViewModel)
    {
        Debug.WriteLine("[DEBUG] RiskScoreViewModel initialized.");
        Debug.WriteLine($"[DEBUG] Dashboard Selected: {dashboardViewModel.SelectedFramework}");

        _dashboardViewModel = dashboardViewModel;

        // Initialize collections
        AllControls = new ObservableCollection<ConceptualCheckBox>();
        AllPhysicalControls = new ObservableCollection<PhysicalControl>();

        // Polling mechanism for checking when the dashboard is populated
        var timer = new System.Windows.Threading.DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            if (_dashboardViewModel.ConceptualControls != null && _dashboardViewModel.ConceptualControls.Count > 0)
            {
                timer.Stop();
                UpdateControls();
                CalculateRiskScore();
                UpdateGraphs();
            }
            else
            {
                Debug.WriteLine("[DEBUG] No ConceptualControls found in dashboard view model or dashboard not yet populated.");
            }
        };
        timer.Start();
    }

    // Method to update both conceptual and physical controls when dashboard is populated
    public void UpdateControls()
    {
        Debug.WriteLine($"[DEBUG] ConceptualControls count in dashboard view model: {_dashboardViewModel.ConceptualControls.Count}");

        // Clear existing controls
        AllControls.Clear();
        AllPhysicalControls.Clear();

        var sortedControls = _dashboardViewModel.ConceptualControls
            .OrderBy(control => severityOrder.ContainsKey(control.Severity) ? severityOrder[control.Severity] : int.MaxValue)
            .ToList();

        foreach (var conceptualControl in sortedControls)
        {
            Debug.WriteLine($"[DEBUG] Adding conceptual control: {conceptualControl.Name}");
            AllControls.Add(conceptualControl);

            foreach (var physicalControl in conceptualControl.PhysicalControls)
            {
                // Subscribe to changes in the Passed property of physical controls
                physicalControl.PropertyChanged += PhysicalControl_PropertyChanged;
                AllPhysicalControls.Add(physicalControl);
            }
        }

        Debug.WriteLine($"[DEBUG] AllControls updated. New count: {AllControls.Count}");
        Debug.WriteLine($"[DEBUG] AllPhysicalControls updated. New count: {AllPhysicalControls.Count}");
    }

    // Event handler for when the "Passed" property of a PhysicalControl changes
    private void PhysicalControl_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PhysicalControl.Passed))
        {
            Debug.WriteLine("[DEBUG] Physical control passed state changed. Updating graphs and risk score.");
            CalculateRiskScore();
            UpdateGraphs();
        }
    }

    // Method to update the graphs dynamically
    private void UpdateGraphs()
    {
        SetupCyberControlBarGraph();
        SetupRiskSeverityModel();
    }

    // Method to setup the cyber control bar graph
    private void SetupCyberControlBarGraph()
    {
        CyberControlBarGraphModel = new PlotModel { Title = "Failed Standards per Severity" };

        var severityGroups = AllControls
            .GroupBy(control => control.Severity)
            .Select(group => new BarItem { Value = group.Count() })
            .ToList();

        var barSeries = new BarSeries
        {
            ItemsSource = severityGroups,
            LabelPlacement = LabelPlacement.Inside,
            LabelFormatString = "{0}"
        };

        CyberControlBarGraphModel.Series.Clear();
        CyberControlBarGraphModel.Series.Add(barSeries);
        CyberControlBarGraphModel.Axes.Add(new CategoryAxis
        {
            Position = AxisPosition.Left,
            ItemsSource = AllControls.Select(control => control.Severity).Distinct().ToList()
        });

        OnPropertyChanged(nameof(CyberControlBarGraphModel));
        Debug.WriteLine("[DEBUG] Cyber Control Bar Graph setup completed.");
    }

    // Method to setup the risk severity pie chart
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

        // Add pie slices based on the count of failed controls by severity
        var failedControls = AllControls.Where(c => c.PhysicalControls.Any(pc => !pc.Passed)).ToList();

        pieSeries.Slices.Add(new PieSlice("Low/Low", failedControls.Count(c => c.Severity == "Low/Low")) { Fill = OxyColors.Green });
        pieSeries.Slices.Add(new PieSlice("Med/Med", failedControls.Count(c => c.Severity == "Med/Med")) { Fill = OxyColors.Orange });
        pieSeries.Slices.Add(new PieSlice("High/High", failedControls.Count(c => c.Severity == "High/High")) { Fill = OxyColors.Red });
        pieSeries.Slices.Add(new PieSlice("Low/Med", failedControls.Count(c => c.Severity == "Low/Med")) { Fill = OxyColors.Yellow });
        pieSeries.Slices.Add(new PieSlice("Med/Low", failedControls.Count(c => c.Severity == "Med/Low")) { Fill = OxyColors.GreenYellow });

        RiskSeverityModel.Series.Clear();
        RiskSeverityModel.Series.Add(pieSeries);

        OnPropertyChanged(nameof(RiskSeverityModel));
        Debug.WriteLine("[DEBUG] Risk Severity Pie Chart setup completed.");
    }

    // Risk score calculation based on severity and failures
    public void CalculateRiskScore()
    {
        double score = 0;
        int totalControls = AllControls.Count;

        foreach (var control in AllControls)
        {
            if (control.PhysicalControls.Any(pc => !pc.Passed))
            {
                switch (control.Severity)
                {
                    case "High/High":
                        score += 10;
                        break;
                    case "Med/Med":
                        score += 6;
                        break;
                    case "Low/Med":
                    case "Med/Low":
                        score += 3;
                        break;
                    case "Low/Low":
                        score += 1;
                        break;
                }
            }
        }

        // Calculate final score as average severity
        if (totalControls > 0)
        {
            RiskScore = score / totalControls;
        }
        else
        {
            RiskScore = 0;  // Default to 0 if no controls
        }

        RiskScore = Math.Min(RiskScore, 10);  // Cap the risk score at 10
        OnPropertyChanged(nameof(RiskScore));
        Debug.WriteLine($"[DEBUG] RiskScore updated: {RiskScore}");
    }
}
