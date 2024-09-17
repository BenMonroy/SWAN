<<<<<<< HEAD
﻿using System;
=======
﻿using CommunityToolkit.Mvvm.ComponentModel;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
>>>>>>> main
using System.Collections.ObjectModel;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using SWAN.Components;

namespace SWAN.ViewModels
{
    public class RiskScoreViewModel
    {
<<<<<<< HEAD
        public ObservableCollection<ControlGroup> ControlGroups { get; set; } = new ObservableCollection<ControlGroup>();
        public PlotModel CyberControlBarGraphModel { get; set; } = new PlotModel();
        public PlotModel RiskSeverityModel { get; set; } = new PlotModel();
        public double RiskScore { get; set; }

        private readonly RMFDashboardViewModel _dashboardViewModel;

        public RiskScoreViewModel(RMFDashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
=======
        public PlotModel CyberControlBarGraphModel { get; private set; } = new PlotModel();
        public PlotModel RiskSeverityModel { get; private set; } = new PlotModel();
        public double RiskScore { get; private set; }
        public RiskScoreViewModel(RMFDashboardViewModel viewModel)
        {
            
            // Bind controls from the dashboard
            //AllControls = dashboardViewModel.CheckBoxCollection;
>>>>>>> main

            // Load controls from the dashboard
            _dashboardViewModel.LoadDoDICollection();

            // Fetch the control names from the dashboard
            FetchControlNames();
        }

        private void FetchControlNames()
        {
            ControlGroups.Clear();

            // Fetch all conceptual controls from the dashboard
            var conceptualControls = GetSelectedDashboardControls();

            if (conceptualControls == null || !conceptualControls.Any())
            {
                return;
            }

            foreach (var conceptualControl in conceptualControls)
            {
                var group = new ControlGroup
                {
                    MajorControlName = conceptualControl.Name
                };

                foreach (var physicalControl in conceptualControl.PhysicalControls.Where(pc => !pc.Passed)) // Filter only unchecked controls
                {
                    group.MinorControls.Add(new MinorControlModel
                    {
                        ControlName = physicalControl.Control,
                        Severity = conceptualControl.Severity,
                        IsChecked = physicalControl.Passed ? "Passed" : "Failed"
                    });
                }

                ControlGroups.Add(group);
            }

            SetupCyberControlBarGraph();
            SetupRiskSeverityModel();
        }

        private void SetupCyberControlBarGraph()
        {
            CyberControlBarGraphModel = new PlotModel { Title = "Failed Standards per Severity" };

            var severityGroups = ControlGroups
                .SelectMany(group => group.MinorControls)
                .GroupBy(control => control.Severity)
                .Select(group => new OxyPlot.Series.BarItem
                {
                    Value = group.Count()
                })
                .ToList();

            var barSeries = new OxyPlot.Series.BarSeries
            {
                ItemsSource = severityGroups,
                LabelPlacement = OxyPlot.Series.LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };

            CyberControlBarGraphModel.Series.Add(barSeries);
            CyberControlBarGraphModel.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                ItemsSource = ControlGroups
                    .SelectMany(group => group.MinorControls)
                    .Select(control => control.Severity)
                    .Distinct()
                    .ToList()
            });
        }

        private void SetupRiskSeverityModel()
        {
            RiskSeverityModel = new PlotModel { Title = "Vulnerabilities by Severity" };

            var pieSeries = new OxyPlot.Series.PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            pieSeries.Slices.Add(new OxyPlot.Series.PieSlice("Low/Low", ControlGroups
                .SelectMany(group => group.MinorControls)
                .Count(c => c.Severity == "Low/Low"))
            { Fill = OxyColors.Green });
            pieSeries.Slices.Add(new OxyPlot.Series.PieSlice("Med/Med", ControlGroups
                .SelectMany(group => group.MinorControls)
                .Count(c => c.Severity == "Med/Med"))
            { Fill = OxyColors.Orange });
            pieSeries.Slices.Add(new OxyPlot.Series.PieSlice("High/High", ControlGroups
                .SelectMany(group => group.MinorControls)
                .Count(c => c.Severity == "High/High"))
            { Fill = OxyColors.Red });
            pieSeries.Slices.Add(new OxyPlot.Series.PieSlice("Low/Med", ControlGroups
                .SelectMany(group => group.MinorControls)
                .Count(c => c.Severity == "Low/Med"))
            { Fill = OxyColors.Yellow });
            pieSeries.Slices.Add(new OxyPlot.Series.PieSlice("Med/Low", ControlGroups
                .SelectMany(group => group.MinorControls)
                .Count(c => c.Severity == "Med/Low"))
            { Fill = OxyColors.GreenYellow });

            RiskSeverityModel.Series.Add(pieSeries);
        }

        private IEnumerable<ConceptualCheckBox> GetSelectedDashboardControls()
        {
            return new List<ConceptualCheckBox>
            {
                _dashboardViewModel.ConceptualControl1,
                _dashboardViewModel.ConceptualControl2,
                _dashboardViewModel.ConceptualControl3,
                _dashboardViewModel.ConceptualControl4,
                _dashboardViewModel.ConceptualControl5,
                _dashboardViewModel.ConceptualControl6,
                _dashboardViewModel.ConceptualControl7,
                _dashboardViewModel.ConceptualControl8,
                _dashboardViewModel.ConceptualControl9,
                _dashboardViewModel.ConceptualControl10,
                _dashboardViewModel.ConceptualControl11,
                _dashboardViewModel.ConceptualControl12,
                _dashboardViewModel.ConceptualControl13,
                _dashboardViewModel.ConceptualControl14,
                _dashboardViewModel.ConceptualControl15,
                _dashboardViewModel.ConceptualControl16,
                _dashboardViewModel.ConceptualControl17,
                _dashboardViewModel.ConceptualControl18,
                _dashboardViewModel.ConceptualControl19,
                _dashboardViewModel.ConceptualControl20,
                _dashboardViewModel.ConceptualControl21,
                _dashboardViewModel.ConceptualControl22,
                _dashboardViewModel.ConceptualControl23,
                _dashboardViewModel.ConceptualControl24,
                _dashboardViewModel.ConceptualControl25,
                _dashboardViewModel.ConceptualControl26,
                _dashboardViewModel.ConceptualControl27,
                _dashboardViewModel.ConceptualControl28,
                _dashboardViewModel.ConceptualControl29
            };
        }
    }

    public class ControlGroup
    {
        public string MajorControlName { get; set; }
        public ObservableCollection<MinorControlModel> MinorControls { get; set; } = new ObservableCollection<MinorControlModel>();
    }

    public class MinorControlModel
    {
        public string ControlName { get; set; }
        public string Severity { get; set; }
        public string IsChecked { get; set; }
    }
}
