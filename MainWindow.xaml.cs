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

        public MainWindow(ScaffoldViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
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