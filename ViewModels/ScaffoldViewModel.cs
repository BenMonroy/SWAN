using System;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAN.Views;

namespace SWAN.ViewModels
{
    public class ScaffoldViewModel : ObservableObject
    {
       private PageId _pageId;

        public PageId PageId
        {
            get { return _pageId; }
            set {  SetProperty(ref _pageId, value);}
        }

        public ICommand ChangePageCommand => new RelayCommand<PageId>(ChangePage);

        void ChangePage(PageId nextPage)
        {
            PageId = nextPage;
        }

        public ScaffoldViewModel()
        {
            // Sets the dashboard view as the default view
            PageId = PageId.RMFDashboardView;

            
        }

        
    }
}
