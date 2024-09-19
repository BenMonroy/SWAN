using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using SWAN.ViewModels;

namespace SWAN.Views
{
    public partial class RiskScoreView : UserControl
    {
        
        public RiskScoreView(RiskScoreViewModel viewModel)
        {
            InitializeComponent(); 
            this.DataContext = viewModel;
        }
    }
}
