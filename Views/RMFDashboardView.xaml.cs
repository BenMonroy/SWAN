using CommunityToolkit.Mvvm.ComponentModel;
using SWAN.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public ObservableCollection<CheckBoxItem> CheckBoxCollection { get; set; }
        // Opens the modal

        public RMFDashboardView(RMFDashboardViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            _viewModel = viewModel;
            
        }

       
        private void OpenModalButton_Click(object sender, RoutedEventArgs e)
        {
            ModalPopup.IsOpen = true;
        }

        // Closes the modal
        private void CloseModalButton_Click(object sender, RoutedEventArgs e)
        {
            ModalPopup.IsOpen = false;
        }
        private void TogglePopup_Click(object sender, RoutedEventArgs e)
        {
            // Get the button that was clicked
            Button clickedButton = sender as Button;

            if (clickedButton == null) return;

            // Retrieve the popup name from the Tag property
            string popupName = clickedButton.Tag as string;

            // Get the Popup control based on the name
            Popup popupToToggle = FindName(popupName) as Popup;

            // Toggle the popup visibility
            if (popupToToggle != null)
            {
                popupToToggle.IsOpen = !popupToToggle.IsOpen;
            }
        }


        //public void OnClickExpand(object sender, RoutedEventArgs e)
        //{
        //    foreach (object item in this.TreeView1.Items)
        //    {
        //        TreeViewItem trItem = this.TreeView1.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
        //        if (trItem != null)
        //        {
        //            ToggleAll(trItem, true);
        //        }
        //        trItem.IsExpanded = true;
        //    }
        //}

        //public void OnClickCollapse(object sender, RoutedEventArgs e)
        //{
        //    foreach (object item in this.TreeView1.Items)
        //    {
        //        TreeViewItem trItem = this.TreeView1.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
        //        if (trItem != null)
        //        {
        //            ToggleAll(trItem, false);
        //        }
        //        trItem.IsExpanded = false;
        //    }
        //}

        //public void ToggleAll(ItemsControl items, bool expand)
        //{
        //    foreach (object obj in items.Items)
        //    {
        //        ItemsControl? childControl = items.ItemContainerGenerator.ContainerFromItem(obj) as ItemsControl;
        //        if (childControl != null)
        //        {
        //            ToggleAll(childControl, expand);
        //        }
        //        TreeViewItem? item = childControl as TreeViewItem;
        //        if (item != null)
        //            item.IsExpanded = expand;
        //    }
        //}

        //public void CheckBoxClick(object sender, RoutedEventArgs e)
        //{
        //    // Assuming MainViewModelInstance.TestsCollection holds your parent items
        //     // and each parent item has a Children collection and an IsSelected property.
        //    foreach (var parent in _viewModel.CheckBoxCollection)
        //    {
        //            int totalChildren = parent.Children.Count;
        //            int selectedChildren = 0;
        //            foreach (var child in parent.Children)
        //            {
        //                if (child.IsSelected == true)
        //                {
        //                    selectedChildren++;
        //                }
        //            }

        //            // Set the parent's IsSelected to true only if all children are selected
        //            if (selectedChildren == totalChildren)
        //            {
        //                    parent.IsSelected = true;

        //            }
        //            if(selectedChildren == 0)
        //                {
        //                    parent.IsSelected = false;
        //                }
        //    }
        //}


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
                    _viewModel.SelectedFramework = "NIST 800-160 Vol. 1";
                    _viewModel.Load800160Command.Execute(null);
                    break;
            }
            RMF_StackPanel.Visibility = Visibility.Hidden;
        }


    }
}
