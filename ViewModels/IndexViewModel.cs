using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using SWAN.Views.WikiPages;
using Wpf.Ui.Controls;

namespace SWAN.ViewModels
{
    public partial class IndexViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new ObservableCollection<object>
        {
            new NavigationViewItem
            {
                Content = "Home",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                Tag = typeof(CM1WikiPage),
                TargetPageType = null
            },
            new NavigationViewItem
            {
                Content = "Design Guidance",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DesignIdeas24 },
                TargetPageType = null,
                MenuItemsSource = new ObservableCollection<object>
                {
                    new NavigationViewItem
                    {
                        Content = "Typography",
                        Icon = new SymbolIcon { Symbol = SymbolRegular.TextFont24 },
                        Tag = typeof(SA10WikiPage)
                    },
                    new NavigationViewItem
                    {
                        Content = "Icons",
                        Icon = new SymbolIcon { Symbol = SymbolRegular.Diversity24 },
                        Tag = typeof(SA11_1_WikiPage)
                    },
                    new NavigationViewItem
                    {
                        Content = "Colors",
                        Icon = new SymbolIcon { Symbol = SymbolRegular.Color24 },
                        Tag = typeof(SA11_2_WikiPage)
                    }
                }
            },
            new NavigationViewItem
            {
                Content = "All Samples",
                Icon = new SymbolIcon { Symbol = SymbolRegular.List24 },
                Tag = typeof(SA11_3_WikiPage),
                TargetPageType = null
            },
            new NavigationViewItemSeparator()
        };
    }
}
