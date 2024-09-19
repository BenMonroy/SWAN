using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SWAN.Services;
using SWAN.ViewModels;
using SWAN.Views;

namespace SWAN.ViewModels
{
    public partial class ScaffoldViewModel : ObservableObject
    {
        [ObservableProperty]
        private PageId pageId;
        [ObservableProperty]
        private RMFDashboardViewModel dashboardViewModel;
        [ObservableProperty]
        private UserControl currentView;
        private readonly RMFDashboardView _rmfDashboardView;
        private readonly HistoryView _historyView;
        private readonly IndexView _indexView;
        private readonly RiskScoreView _riskScoreView;

     
        private string _currentFilePath = string.Empty;
       


        public ICommand ChangePageCommand => new RelayCommand<PageId>(ChangePage);
        public ICommand SaveCommand => new RelayCommand(Save);
        public ICommand SaveAsCommand => new RelayCommand(SaveAs);
        public ICommand OpenFileCommand => new RelayCommand(OpenFile);

        public ICommand OpenSettingsCommand = new RelayCommand(OpenSettingsMenu);

        public static ICommand TodoCommand => new RelayCommand(() => MessageBox.Show("not implemented!"));



        public ICommand HandleFrameworkSelectionCommand => new RelayCommand<string>(NewFile);
        private readonly IMessenger _messenger;



        public ScaffoldViewModel(
        RMFDashboardViewModel dashboardViewModel,
        HistoryView historyView,
        IndexView indexView,
        RiskScoreView riskScoreView,
        RMFDashboardView rmfDashboardView, IMessenger messenger)
        {
            DashboardViewModel = dashboardViewModel;
            _historyView = historyView;
            _indexView = indexView;
            _riskScoreView = riskScoreView;
            _rmfDashboardView = rmfDashboardView;
            CurrentView = _rmfDashboardView;
            _messenger = messenger;
            //register/subscribe to the file opened in rmfdashboardviewmodel
            _messenger.Register<ScaffoldViewModel, FileOpenedMessage>(this, (r, m) =>
            {
                r._currentFilePath = m.Value; // Save the file path
            });
        }

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
                    CurrentView = _historyView;
                    break;
            }
        }


        private async void Save()
        {
            //checks to see if previously saved, if not do saveAs
            if (!string.IsNullOrEmpty(_currentFilePath))
            {
                await DashboardViewModel.SaveStateAsync(_currentFilePath);
                MessageBox.Show("File saved successfully.");
            }
            else
            {
                SaveAs(); // Prompt Save As if no file is currently open
            }
        }


        private async void SaveAs()
        {
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                FileName = string.IsNullOrEmpty(_currentFilePath) ? "" : System.IO.Path.GetFileName(_currentFilePath),
                DefaultExt = ".json",  
                Filter = "JSON files (.json)|*.json"  
            };

            if (!string.IsNullOrEmpty(_currentFilePath) && System.IO.File.Exists(_currentFilePath))
            {
                dialog.InitialDirectory = System.IO.Path.GetDirectoryName(_currentFilePath);
            }

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _currentFilePath = dialog.FileName;
                try
                {
                    await DashboardViewModel.SaveStateAsync(_currentFilePath);
                    MessageBox.Show("File saved successfully as JSON.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: Could not save file. {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Operation cancelled.");
            }
        }

        private static void OpenSettingsMenu()
        {
            throw new NotImplementedException();
        }

        private void NewFile(string framework)
        {
            _currentFilePath = string.Empty;
            DashboardViewModel.CreateNewFile(framework); 
        }



        private async void OpenFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "",
                DefaultExt = ".json",
                Filter = "JSON files (.json)|*.json"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _currentFilePath = dialog.FileName;
                try
                {
                    await DashboardViewModel.LoadStateAsync(_currentFilePath);
                    DashboardViewModel.ToggleRMFStackPanelVisibility();
                    MessageBox.Show("File loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: Could not open file. {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Operation cancelled.");
            }
        }

    }
}
