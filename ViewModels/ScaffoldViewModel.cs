using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAN.ViewModels;

namespace SWAN.ViewModels
{
    public class ScaffoldViewModel : ObservableObject
    {
        private PageId _pageId;
        private RMFDashboardViewModel _dashboardViewModel;

        private string CurrentFilePath = string.Empty;

        public PageId PageId
        {
            get { return _pageId; }
            set { SetProperty(ref _pageId, value); }
        }

        public RMFDashboardViewModel DashboardViewModel
        {
            get => _dashboardViewModel;
            set => SetProperty(ref _dashboardViewModel, value);
        }

        public ICommand ChangePageCommand => new RelayCommand<PageId>(ChangePage);
        public ICommand SaveCommand => new RelayCommand(Save);
        public ICommand SaveAsCommand => new RelayCommand(SaveAs);
        public ICommand OpenFileCommand => new RelayCommand(OpenFile);

        void ChangePage(PageId nextPage)
        {
            PageId = nextPage;
        }

        private void Save()
        {
            if (!string.IsNullOrEmpty(CurrentFilePath))
            {
                DashboardViewModel.SaveStateToCsv(CurrentFilePath);
                MessageBox.Show("File saved successfully.");
            }
            else
            {
                SaveAs(); // Prompt Save As if no file is currently open
            }
        }

        private void SaveAs()
        {
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "Document",
                DefaultExt = ".csv",
                Filter = "CSV files (.csv)|*.csv"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                CurrentFilePath = dialog.FileName;
                DashboardViewModel.SaveStateToCsv(CurrentFilePath);
                MessageBox.Show("File Saved");
            }
            else
            {
                MessageBox.Show("Error: Could Not Save File");
            }
        }

        private void OpenFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Document",
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                // Handle opening the file
                string filename = dialog.FileName;
                // Implement file loading logic here
            }
        }

        public ScaffoldViewModel()
        {
            PageId = PageId.RMFDashboardView;
            _dashboardViewModel = new RMFDashboardViewModel();
        }
    }
}
