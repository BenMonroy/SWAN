using SWAN.ViewModels;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;

namespace SWAN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Change this when choosing a file
        private string currentFilePath = string.Empty;

        private ScaffoldViewModel _viewModel;
        public MainWindow(ScaffoldViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            _viewModel = viewModel;
        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeOnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeOnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }


        //Todo must be some try/catch block with a popup if already in an active dashboard
        private void NewFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            string selectedFramework = menuItem.Header.ToString();
            if(emptyChangeDashboard()){
                _viewModel.HandleFrameworkSelectionCommand.Execute(menuItem.Header.ToString());
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Opening a new Dashboard will erase any unsaved changes. Do you want to proceed?", "Confirm Action", MessageBoxButton.YesNo);

                // Perform actions based on the user's choice
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.HandleFrameworkSelectionCommand.Execute(menuItem.Header.ToString());
                }
                else if (result == MessageBoxResult.No)
                {
                    // User clicked No, perform a different operation or handle cancellation
                }

            }
        }

        //TODO this has got to be done much better
        private bool emptyChangeDashboard() { return _viewModel.DashboardViewModel.CheckBoxCollection.Count == 0; }

        private void TitleBarButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ContextMenu cm = btn.ContextMenu;
                if (cm != null)
                {
                    cm.PlacementTarget = btn;
                    cm.Placement = PlacementMode.Bottom;
                    cm.IsOpen = true;
                }
            }
        }
    }
}