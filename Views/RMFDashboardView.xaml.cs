using SWAN.Components;
using SWAN.ViewModels;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using TreeViewItem = Wpf.Ui.Controls.TreeViewItem;

namespace SWAN.Views
{
    /// <summary>
    /// Interaction logic for RMFDashboardView.xaml
    /// </summary>
    public partial class RMFDashboardView : UserControl
    {
        private RMFDashboardViewModel _viewModel;



        public RMFDashboardView(RMFDashboardViewModel viewModel) : this()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            _viewModel = viewModel;
        }

        public RMFDashboardView()
        {
        }





        public void ToggleAll(ItemsControl items, bool expand)
        {
            foreach (object obj in items.Items)
            {
                ItemsControl? childControl = items.ItemContainerGenerator.ContainerFromItem(obj) as ItemsControl;
                if (childControl != null)
                {
                    ToggleAll(childControl, expand);
                }
                TreeViewItem? item = childControl as TreeViewItem;
                if (item != null)
                    item.IsExpanded = expand;
            }
        }



        private async void FileChosenFromSearch(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            if (e.SelectedItem is RecentFile selectedFile)
            {
                try
                {
                    await _viewModel.LoadStateAsync(selectedFile.FilePath);
                    _viewModel.ToggleRMFStackPanelVisibility();
                    System.Windows.MessageBox.Show("File loaded Successfully");
                }
                catch (Exception ex) { System.Windows.MessageBox.Show("$ex"); }
            }
            else
            {
                System.Windows.MessageBox.Show("Error: Could not open file.");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}