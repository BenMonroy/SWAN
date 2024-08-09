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
        public ObservableCollection<CheckBoxItem> testViewCollection = new ObservableCollection<CheckBoxItem>();
        public RMFDashboardView(RMFDashboardViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            testViewCollection = viewModel.TestsCollection;

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
                ItemsControl childControl = items.ItemContainerGenerator.ContainerFromItem(obj) as ItemsControl;
                if (childControl != null)
                {
                    ToggleAll(childControl, expand);
                }
                TreeViewItem item = childControl as TreeViewItem;
                if (item != null)
                    item.IsExpanded = expand;
            }
        }

        public void CheckBoxClick(object sender, RoutedEventArgs e)
{
    // Assuming MainViewModelInstance.TestsCollection holds your parent items
    // and each parent item has a Children collection and an IsSelected property.
    
    foreach (var parent in this.testViewCollection)
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
            if(selectedChildren == 0)
                {
                    parent.IsSelected = false;
                }
    }
}


    }
}
