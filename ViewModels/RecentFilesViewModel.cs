using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAN.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWAN.ViewModels
{
    public class RecentFilesViewModel : ObservableObject
    {
        private readonly RecentFilesManager _recentFilesManager;

        private ObservableCollection<RecentFile> _recentFiles;
        public ObservableCollection<RecentFile> RecentFiles
        {
            get => _recentFiles;
            set => SetProperty(ref _recentFiles, value);
        }

        public ICommand OpenFileCommand { get; }
        public ICommand RemoveFileCommand { get; }

        public RecentFilesViewModel()
        {
            _recentFilesManager = new RecentFilesManager();
            RecentFiles = new ObservableCollection<RecentFile>(_recentFilesManager.LoadRecentFiles());

            OpenFileCommand = new RelayCommand<RecentFile>(OpenFile);
            RemoveFileCommand = new RelayCommand<RecentFile>(RemoveFile);
        }

        private void OpenFile(RecentFile recentFile)
        {
            if (recentFile != null)
            {
                // Open the file using the default application
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = recentFile.FilePath,
                    UseShellExecute = true
                });
            }
        }

        private void RemoveFile(RecentFile recentFile)
        {
            if (recentFile != null)
            {
                RecentFiles.Remove(recentFile);
                _recentFilesManager.RemoveRecentFile(recentFile.FilePath);
            }
        }
    }
}
