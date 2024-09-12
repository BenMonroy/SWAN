using System.Windows.Controls;

namespace SWAN.Views
{
    public partial class IndexView : UserControl
    {
        public IndexView()
        {
            InitializeComponent();
        }

        // Event handler for SelectionChanged
        private void Sidebar_SelectionChangedRMF1(object sender, SelectionChangedEventArgs e)
        {
            if (sidebar.SelectedItem is ListBoxItem selectedItem)
            {
                // Get the text of the selected item
                string selectedText = selectedItem.Content.ToString();

                // Perform navigation based on the selected item
                switch (selectedText)
                {
                    case "Page 1":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/CM1WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "Page 2":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA3WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "Page 3":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/WikiPageTemplate.xaml", System.UriKind.Relative));
                        break;
                    default:
                        break;
                }
            }
        }

        private void Sidebar_SelectionChangedRMF2(object sender, SelectionChangedEventArgs e)
        {
            if (sidebar2.SelectedItem is ListBoxItem selectedItem)
            {
                // Get the text of the selected item
                string selectedText = selectedItem.Content.ToString();

                // Perform navigation based on the selected item
                switch (selectedText)
                {
                    case "Page 1":
                        ContentFrame2.Navigate(new System.Uri("Views/WikiPages/CM1WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "Page 2":
                        ContentFrame2.Navigate(new System.Uri("Views/WikiPages/SA3WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "Page 3":
                        ContentFrame2.Navigate(new System.Uri("Views/WikiPages/WikiPageTemplate.xaml", System.UriKind.Relative));
                        break;
                    default:
                        break;
                }
            }
        }
        private void Sidebar_SelectionChangedRMF3(object sender, SelectionChangedEventArgs e)
        {
            if (sidebar3.SelectedItem is ListBoxItem selectedItem)
            {
                // Get the text of the selected item
                string selectedText = selectedItem.Content.ToString();

                // Perform navigation based on the selected item
                switch (selectedText)
                {
                    case "Page 1":
                        ContentFrame3.Navigate(new System.Uri("Views/WikiPages/CM1WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "Page 2":
                        ContentFrame3.Navigate(new System.Uri("Views/WikiPages/SA3WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "Page 3":
                        ContentFrame3.Navigate(new System.Uri("Views/WikiPages/WikiPageTemplate.xaml", System.UriKind.Relative));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
