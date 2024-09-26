using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

//NEED TO REFACTOR FOR OPTIMIZATION
//GOOD FOR NOW
//ON REFACTOR USE DICTIONARY TO MAP TEXT
namespace SWAN.Views
{
    public partial class IndexView : UserControl
    {
        
        private List<ListBoxItem> sa3SubItems;
        private List<ListBoxItem> sa4SubItems;
        private List<ListBoxItem> sa4_2SubItems;
        private List<ListBoxItem> sa4_3SubItems;
        private List<ListBoxItem> sa10SubItems;
        private List<ListBoxItem> sa11SubItems;
        private List<ListBoxItem> sa11_1SubItems;
        private List<ListBoxItem> sa11_2SubItems;
        private List<ListBoxItem> sa11_3SubItems;
        private List<ListBoxItem> sa11_4SubItems;
        private List<ListBoxItem> sa11_5SubItems;
        private List<ListBoxItem> sa11_6SubItems;
        private List<ListBoxItem> sa11_8SubItems;
        private List<ListBoxItem> sa12SubItems;
        public IndexView()
        {
            InitializeComponent();
            sa3SubItems = new List<ListBoxItem>
            {
                SA3numberoneItem,
                SA3numbertwoItem,
                SA3numberthreeItem
            };
            sa4SubItems = new List<ListBoxItem>
            {
                SA4numberoneItem,
                SA4numbertwoItem
            };
            sa4_2SubItems = new List<ListBoxItem>
            {
              SA4_2_numberoneItem,
              SA4_2_numbertwoItem,
              SA4_2_numberthreeItem
            };
            sa4_3SubItems = new List<ListBoxItem>
            {
              SA4_3_numberoneItem,
              SA4_3_numbertwoItem
            };
            sa10SubItems = new List<ListBoxItem>
            {
                numberoneItem,
                numbertwoItem,
                numberthreeItem,
                numberfourItem,
                numberfiveItem,
                numbersixItem,
                numbersevenItem
            };
            sa11SubItems = new List<ListBoxItem>
            {
                SA11numberoneItem,
                SA11numbertwoItem,
                SA11numberthreeItem,

            };
            sa11_1SubItems = new List<ListBoxItem>
            {
                SA11_1_numberoneItem,
                SA11_1_numbertwoItem,
                SA11_1_numberthreeItem,

            };
            sa11_2SubItems = new List<ListBoxItem>
            {
                SA11_2_numberoneItem,
                SA11_2_numbertwoItem,
                SA11_2_numberthreeItem,
                SA11_2_numberfourItem,
            };
            sa11_3SubItems = new List<ListBoxItem>
            {
                SA11_3_numberoneItem,
                SA11_3_numbertwoItem,
                SA11_3_numberthreeItem,
                SA11_3_numberfourItem,
            };
            sa11_4SubItems = new List<ListBoxItem>
            {
                SA11_4_numberoneItem,
                SA11_4_numbertwoItem,
            };
            sa11_5SubItems = new List<ListBoxItem>
            {
                SA11_5_numberoneItem,
                SA11_5_numbertwoItem,
            };
            sa11_6SubItems = new List<ListBoxItem>
            {
                SA11_6_numberoneItem,
                SA11_6_numbertwoItem,
                SA11_6_numberthreeItem,
            };
            sa11_8SubItems = new List<ListBoxItem>
            {
                SA11_8_numberoneItem,
                SA11_8_numbertwoItem,
                SA11_8_numberthreeItem,
            };
            sa12SubItems = new List<ListBoxItem>
            {
                SA12numberoneItem,
                SA12numbertwoItem,
                SA12numberthreeItem,
            };
            
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
                collapse_subnavigation();
                
                // Perform navigation based on the selected item
                switch (selectedText)
                {
                    case "CM-1":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/CM1WikiPage.xaml", System.UriKind.Relative));
                        CM1numberoneItem.Visibility = Visibility.Visible;
                        break;
                    case "CM1numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.CM1WikiPage());
                        CM1numberoneItem.Visibility = Visibility.Visible;
                        break;
                    case "SA-3":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA3WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA3numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA3WikiPage());
                        foreach (var item in sa3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA3numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA3WikiPage());
                        foreach (var item in sa3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA3numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA3WikiPage());
                        foreach (var item in sa3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-4":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA4WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa4SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4WikiPage());
                        foreach (var item in sa4SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4WikiPage());
                        foreach (var item in sa4SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-4(2)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA4_2_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa4_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4_2_numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4_2_WikiPage());
                        foreach (var item in sa4_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4_2_numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4_2_WikiPage());
                        foreach (var item in sa4_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4_2_numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4_2_WikiPage());
                        foreach (var item in sa4_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4_2_numberfour":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4_2_WikiPage());
                        foreach (var item in sa4_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-4(3)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA4_3_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa4_3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4_3_numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4_3_WikiPage());
                        foreach (var item in sa4_3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA4_3_numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA4_3_WikiPage());
                        foreach (var item in sa4_3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-8":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA8WikiPage.xaml", System.UriKind.Relative));
                        SA8numberoneItem.Visibility = Visibility.Visible;
                        break;
                    case "SA8numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA8WikiPage());
                        SA8numberoneItem.Visibility = Visibility.Visible;
                        break;
                    case "SA-10":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA10WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numberfour":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numberfive":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numbersix":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "numberseven":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA10WikiPage());
                        foreach (var item in sa10SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11WikiPage());
                        foreach (var item in sa11SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11WikiPage());
                        foreach (var item in sa11SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11WikiPage());
                        foreach (var item in sa11SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11(1)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_1_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_1SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_1_numberone":
                    case "SA11_1_numbertwo":
                    case "SA11_1_numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_1_WikiPage());
                        foreach (var item in sa11_1SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;

                    case "SA-11(2)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_2_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_2_numberone":
                    case "SA11_2_numbertwo":
                    case "SA11_2_numberthree":
                    case "SA11_2_numberfour":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_2_WikiPage());
                        foreach (var item in sa11_2SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11(3)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_3_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_3_numberone":
                    case "SA11_3_numbertwo":
                    case "SA11_3_numberthree":
                    case "SA11_3_numberfour":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_3_WikiPage());
                        foreach (var item in sa11_3SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11(4)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_4_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_4SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_4_numberone":
                    case "SA11_4_numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_4_WikiPage());
                        foreach (var item in sa11_4SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11(5)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_5_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_5SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_5_numberone":
                    case "SA11_5_numbertwo":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_5_WikiPage());
                        foreach (var item in sa11_5SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11(6)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_6_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_6SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_6_numberone":
                    case "SA11_6_numbertwo":
                    case "SA11_6_numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_6_WikiPage());
                        foreach (var item in sa11_6SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-11(7)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_7_WikiPage.xaml", System.UriKind.Relative));
                        SA11_7_numberoneItem.Visibility = Visibility.Visible;
                        break;
                    case "SA11_7_numberone":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_7_WikiPage());
                        SA11_7_numberoneItem.Visibility = Visibility.Visible;
                        break;
                    case "SA-11(8)":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA11_8_WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa11_8SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA11_8_numberone":
                    case "SA11_8_numbertwo":
                    case "SA11_8_numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA11_8_WikiPage());
                        foreach (var item in sa11_8SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA-12":
                        ContentFrame.Navigate(new System.Uri("Views/WikiPages/SA12WikiPage.xaml", System.UriKind.Relative));
                        foreach (var item in sa12SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        break;
                    case "SA12numberone":
                    case "SA12numbertwo":
                    case "SA12numberthree":
                        Application.Current.Properties["SubsectionName"] = selectedText;
                        ContentFrame.Navigate(new SWAN.Views.WikiPages.SA12WikiPage());
                        foreach (var item in sa12SubItems)
                        {
                            item.Visibility = Visibility.Visible;
                        }
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
        private void collapse_subnavigation()
        {
            foreach (var item in sa3SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa10SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa4_2SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa4_3SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa4SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_1SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_2SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_3SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_4SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_5SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_6SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa11_8SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            foreach (var item in sa12SubItems)
            {
                item.Visibility = Visibility.Collapsed;
            }
            CM1numberoneItem.Visibility = Visibility.Collapsed; 
            SA8numberoneItem.Visibility = Visibility.Collapsed;
            SA11_7_numberoneItem.Visibility = Visibility.Collapsed;
        }
    }
}
