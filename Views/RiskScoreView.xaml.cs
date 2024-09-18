using System.Diagnostics;
using System.Windows;
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
            Debug.WriteLine($"[DEBUG] RiskScoreView initialized with dashboard: {dashboardViewModel.SelectedFramework}");
            DataContext = ViewModel;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;
            if (expander != null)
            {
                Debug.WriteLine($"[DEBUG] Expander opened: {expander.Header}");
            }
        }
    }
}
