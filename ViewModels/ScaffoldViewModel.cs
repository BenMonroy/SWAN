using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAN.ViewModels;
using SWAN.Views;

namespace SWAN.ViewModels
{
    public class ScaffoldViewModel : ObservableObject
    {
        private PageId _pageId;
        private RMFDashboardViewModel _dashboardViewModel;
        private UserControl _currentView;
        private readonly RMFDashboardView _rmfDashboardView;
        private readonly HistoryView _historyView;
        private readonly IndexView _indexView;
        private readonly RiskScoreView _riskScoreView;

        public UserControl CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

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

        private void ChangePage(PageId nextPage)
        {
            switch (nextPage)
            {
                case PageId.HistoryView:
                    CurrentView = _historyView;
                    break;
                case PageId.RiskScoreView:
                    CurrentView = _riskScoreView;
                    break;
                case PageId.IndexView:
                    CurrentView = _indexView;
                    break;
                case PageId.RMFDashboardView:
                    CurrentView = _rmfDashboardView;
                    break;
                default:
                    CurrentView = _historyView; // Fallback to HistoryView
                    break;
            }
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

        public ScaffoldViewModel(
       RMFDashboardViewModel dashboardViewModel,
       HistoryView historyView,
       IndexView indexView,
       RiskScoreView riskScoreView,
       RMFDashboardView rmfDashboardView)
        {
            _dashboardViewModel = dashboardViewModel;
            _historyView = historyView;
            _indexView = indexView;
            _riskScoreView = riskScoreView;
            _rmfDashboardView = rmfDashboardView;
            CurrentView = _rmfDashboardView;
        }
    }
}
