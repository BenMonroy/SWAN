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

        public RiskScoreView(RiskScoreViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }
    }
}
