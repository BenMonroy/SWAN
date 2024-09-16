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

        

        private void Create_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Framework_ComboBox.SelectedIndex;
            switch (selectedIndex)
            {
                case 0: // case for "DoDI 8510.01"
                    _viewModel.SelectedFramework = "DoDI 8510.01";
                    _viewModel.LoadDoDICommand.Execute(null);
                    break;
                case 1:
                    // Action for "NIST SP 800.53 Rev. 5"
                    _viewModel.SelectedFramework = "NIST SP 800.53 Rev. 5";
                    _viewModel.Load80053Command.Execute(null);
                    break;
                case 2:
                    // Action for "NIST SP 800-37 Rev. 2"
                    _viewModel.SelectedFramework = "NIST SP 800-37 Rev. 2";
                    _viewModel.Load80037Command.Execute(null);
                    break;
                case 3:
                    // Action for "NIST SP 800-160 Vol. 1"
                    _viewModel.SelectedFramework = "NIST SP 800-160 Vol. 1";
                    _viewModel.Load800160Command.Execute(null);
                    break;
            }
            _viewModel.ToggleRMFStackPanelVisibility();
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
    }
}
