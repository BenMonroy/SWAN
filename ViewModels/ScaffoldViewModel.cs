using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAN.Views;

namespace SWAN.ViewModels
{
    public class ScaffoldViewModel : ObservableObject
    {
        private object _currentContentView;
        public object CurrentContentView
        {
            get { return _currentContentView; }
            set { SetProperty(ref _currentContentView, value); }
        }

        public RelayCommand NavigateToIndexCommand { get; private set; }
        public RelayCommand NavigateToDashboardCommand { get; private set; }
        public RelayCommand NavigateToRiskScoreCommand { get; private set; }
        public RelayCommand NavigateToHistoryCommand { get; private set; }

        public ScaffoldViewModel()
        {
            // Set default view
            CurrentContentView = new RMFDashboardView();

            // Initialize commands
            NavigateToIndexCommand = new RelayCommand(NavigateToIndex);
            NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
            NavigateToRiskScoreCommand = new RelayCommand(NavigateToRiskScore);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
        }

        private void NavigateToIndex()
        {
            CurrentContentView = new IndexView();
        }

        private void NavigateToDashboard()
        {
            CurrentContentView = new RMFDashboardView();
        }

        private void NavigateToRiskScore()
        {
            CurrentContentView = new RiskScoreView();
        }

        private void NavigateToHistory()
        {
            CurrentContentView = new HistoryView();
        }
    }
}
