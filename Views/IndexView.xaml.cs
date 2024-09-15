using System.Windows;
using System.Windows.Controls;

namespace SWAN.Views
{
    public partial class IndexView : UserControl
    {
        public IndexView()
        {
            InitializeComponent();

            sidebar.SelectedIndex = 0;
            sidebar2.SelectedIndex = 0;
            sidebar3.SelectedIndex = 0;
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
                    case "CM-1":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/CM1WikiPage.xaml", System.UriKind.Relative));
                        break;
                    
                    case "SA-3":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA3WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "SA-4":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA4WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "SA-4(2)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA4_2_WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "SA-4(3)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA4_3_WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "SA-8":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA8WikiPage.xaml", System.UriKind.Relative));
                        break;
                    case "SA-10":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA10WikiPage.xaml", System.UriKind.Relative));
                        break;
                    //case "numberone":
                    //    Application.Current.Properties["SubsectionName"] = selectedText;
                    //    ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA10WikiPage.xaml", System.UriKind.Relative));
                    //    break;
                    //case "numbertwo":
                    //    Application.Current.Properties["SubsectionName"] = selectedText;
                    //    ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA10WikiPage.xaml", System.UriKind.Relative));
                    //    break;
                    //case "numberthree":
                    //    Application.Current.Properties["SubsectionName"] = selectedText;
                    //    ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA10WikiPage.xaml", System.UriKind.Relative));
                    //    break;
                    case "SA-11":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11WikiPage.xaml", System.UriKind.Relative));
                        break;
                    default:
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/CM1WikiPage.xaml", System.UriKind.Relative));
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
