using CommunityToolkit.Mvvm.ComponentModel;
using SWAN.Components;
using SWAN.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public void OnClickExpand(object sender, RoutedEventArgs e)
        {
            foreach (object item in this.TreeView1.Items)
            {
                TreeViewItem trItem = this.TreeView1.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (trItem != null)
                {
                    ToggleAll(trItem, true);
                }
                trItem.IsExpanded = true;
            }
        }

        public void OnClickCollapse(object sender, RoutedEventArgs e)
        {
            foreach (object item in this.TreeView1.Items)
            {
                TreeViewItem trItem = this.TreeView1.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (trItem != null)
                {
                    ToggleAll(trItem, false);
                }
                trItem.IsExpanded = false;
            }
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

        public void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            // Assuming MainViewModelInstance.TestsCollection holds your parent items
            // and each parent item has a Children collection and an IsSelected property.
            foreach (var parent in _viewModel.CheckBoxCollection)
            {
                int totalChildren = parent.Children.Count;
                int selectedChildren = 0;
                foreach (var child in parent.Children)
                {
                    if (child.IsSelected == true)
                    {
                        selectedChildren++;
                    }
                }

                // Set the parent's IsSelected to true only if all children are selected
                if (selectedChildren == totalChildren)
                {
                    parent.IsSelected = true;

                }
                if (selectedChildren == 0)
                {
                    parent.IsSelected = false;
                }
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
                    // Action for "NIST 800-160 Vol. 1"
                    _viewModel.SelectedFramework = "NIST SP 800-160 Vol. 1";
                    _viewModel.Load800160Command.Execute(null);
                    break;
            }
            _viewModel.ToggleRMFStackPanelVisibility();
        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure there is a newly selected item
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is RecentFile selectedFileItem)
            {
                // Check if the ViewModel and Command are set up correctly
                if (selectedFileItem != null)
                {
                    //TODO fix search bar logic/implementation before actually opening a file
                    //right now it opens first file matching any char, does not wait for you to type whole file or select from list
                    //_viewModel.OpenRecentFileCommand.Execute(selectedFileItem);
                }
                else
                {
                    MessageBox.Show("Error trying to open recent file.");
                }
            }
        }

    }
}
