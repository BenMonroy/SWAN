using System.Windows.Controls;
using SWAN.ViewModels;

namespace SWAN.Views
{
    public partial class RiskScoreView : UserControl
    {
        public RiskScoreViewModel ViewModel { get; private set; }

        public RiskScoreView(RMFDashboardViewModel dashboardViewModel)
        {
            InitializeComponent();
            // Initialize the ViewModel with the dashboard view model
            ViewModel = new RiskScoreViewModel(dashboardViewModel);
            DataContext = ViewModel;
        }
    }
}
