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
        // parameterless constructor since this is required by the content control
        public RiskScoreView()
        {
        }

        public RiskScoreView(RiskScoreViewModel viewModel) : this() // makes the paramterless constructor call this
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
