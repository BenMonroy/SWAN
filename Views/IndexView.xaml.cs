using System.Windows;
using System.Windows.Controls;
using SWAN.ViewModels;
using Wpf.Ui.Controls; // Namespace for NavigationView
using System;
using MessageBox = System.Windows.MessageBox;
using MessageBoxButton = System.Windows.MessageBoxButton;
using Wpf.Ui;

namespace SWAN.Views
{
    public partial class IndexView : UserControl
    {
        public IndexView(
            IndexViewModel viewModel
        )
        {
            InitializeComponent();
            this.DataContext = new IndexViewModel();
        }

        private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
        {

            if (sender is not NavigationView navigationView)
            {
                //MessageBox.Show(
                //    "Navigated to Error",
                //    "Alert",
                //    MessageBoxButton.OK,
                //    MessageBoxImage.Information
                //);
                return;
            }
            // Get the selected NavigationViewItem
            if (navigationView.SelectedItem is NavigationViewItem selectedItem)
            {
                // Get the target page type from Tag
                Type targetPageType = selectedItem.Tag as Type;
                
                //if ((string)selectedItem.Content == "SA-3")
                //{
                    //MessageBox.Show(
                    //    $"Navigated toooo {selectedItem.Content}",
                    //    "Alert",
                    //    MessageBoxButton.OK,
                    //    MessageBoxImage.Information
                    //);
                    //ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA3WikiPage.xaml", System.UriKind.Relative));
                //}

            }
        }

        private void Sidebar_SelectionChangedRMF2(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox sidebar && sidebar.SelectedItem is ListBoxItem selectedItem)
            {
                // Handle selection for RMF2
                MessageBox.Show(
                    $"RMF2 Selected: {selectedItem.Content}",
                    "Alert",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                // Optionally navigate to a page
                // ContentFrame2.Navigate(typeof(SomeOtherPage));
            }
        }

        private void Sidebar_SelectionChangedRMF3(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox sidebar && sidebar.SelectedItem is ListBoxItem selectedItem)
            {
                // Handle selection for RMF3
                MessageBox.Show(
                    $"RMF3 Selected: {selectedItem.Content}",
                    "Alert",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                // Optionally navigate to a page
                // ContentFrame3.Navigate(typeof(AnotherPage));
            }
        }
    }
}
