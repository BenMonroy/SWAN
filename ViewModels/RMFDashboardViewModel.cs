using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.FileIO;
using SWAN.Components;
using SWAN.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWAN.ViewModels
{
    public partial class RMFDashboardViewModel : ObservableObject

    {

        //TODO add a binding visibility here for RMF stack panel, change other refeernces to stack panel to this property

        [ObservableProperty]
        private Visibility _RmfStackPanelVisibility = Visibility.Visible;

        [ObservableProperty]
        private Visibility checkBoxesVisibility = Visibility.Hidden;

        [ObservableProperty]
        public String selectedFramework = "Risk Management Framework Dashboard";

        private RecentFilesManager _recentFilesManager = new RecentFilesManager();

        [ObservableProperty]
        private UserControl fileView;

        [ObservableProperty]
        public ObservableCollection<RecentFile> recentFiles;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl1;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl2;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl3;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl4;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl5;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl6;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl7;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl8;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl9;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl10;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl11;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl12;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl13;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl14;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl15;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl16;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl17;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl18;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl19;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl20;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl21;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl22;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl23;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl24;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl25;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl26;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl27;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl28;

        [ObservableProperty]
        public ConceptualCheckBox conceptualControl29;

        public ObservableCollection<ConceptualCheckBox> ConceptualControls { get; set; }


        public RMFDashboardViewModel(RecentFilesView fileView)
        {
            FileView = fileView;
            RecentFiles = new ObservableCollection<RecentFile>(_recentFilesManager.LoadRecentFiles());
            ConceptualControls = new ObservableCollection<ConceptualCheckBox>();

        }


        public ICommand LoadDoDICommand => new RelayCommand(LoadDoDICollection);
        public ICommand Load80053Command => new RelayCommand(Load80053Collection);
        public ICommand Load80037Command => new RelayCommand(Load80037Collection);
        public ICommand Load800160Command => new RelayCommand(Load800160Collection);
        public ICommand NewFileCommand => new RelayCommand<string>(CreateNewFile);
        public ICommand OpenRecentFileCommand => new RelayCommand<RecentFile>(OpenRecentFile);
        public ICommand RemoveFileCommand => new RelayCommand<RecentFile>(RemoveFile);




        // Example of changing visibility
        public void ToggleRMFStackPanelVisibility()
        {
            RmfStackPanelVisibility = Visibility.Hidden;
            CheckBoxesVisibility = Visibility.Visible;
        }

        // Event to notify when controls are populated
        public event Action OnControlsPopulated;

        private void Load80053Collection()
        {
            ConceptualControl1 = new ConceptualCheckBox
            {
                Severity = "Low/Low",
                CIA = "HHH",
                Name = "Conceptual Control 1",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 2",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 3",
                Severity = "High/High",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1"    , Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 4",
                Severity = "Med/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 5",
                Severity = "Low/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControls = new ObservableCollection<ConceptualCheckBox>
            {
        ConceptualControl1, ConceptualControl2, ConceptualControl3, ConceptualControl4,
        ConceptualControl5 };
            // Trigger the event to notify that the controls have been populated
            OnControlsPopulated?.Invoke();

        }

        private void Load80037Collection()
        {
            ConceptualControl1 = new ConceptualCheckBox
            {
                Severity = "Low/Low",
                CIA = "HHH",
                Name = "Conceptual Control 1",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 2",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 3",
                Severity = "High/High",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1"    , Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 4",
                Severity = "Med/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 5",
                Severity = "Low/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControls = new ObservableCollection<ConceptualCheckBox>
            {
        ConceptualControl1, ConceptualControl2, ConceptualControl3, ConceptualControl4,
        ConceptualControl5 };
            // Trigger the event to notify that the controls have been populated
            OnControlsPopulated?.Invoke();

        }
        private void Load800160Collection()
        {
            ConceptualControl1 = new ConceptualCheckBox
            {
                Severity = "Low/Low",
                CIA = "HHH",
                Name = "Conceptual Control 1",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 2",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 3",
                Severity = "High/High",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1"    , Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 4",
                Severity = "Med/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 5",
                Severity = "Low/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControls = new ObservableCollection<ConceptualCheckBox>
            {
        ConceptualControl1, ConceptualControl2, ConceptualControl3, ConceptualControl4,
        ConceptualControl5 };
            // Trigger the event to notify that the controls have been populated
            OnControlsPopulated?.Invoke();
        }
        public RecentFile CreateRecentFile(string filePath)
        {
            // Ensure the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found!", filePath);
            }
            string fileName = Path.GetFileName(filePath);
            string rmfType = SelectedFramework;
            DateTime lastOpened = File.GetLastWriteTime(filePath);
            return new RecentFile
            {
                FilePath = filePath,
                Name = fileName,
                RmfType = rmfType,
                LastOpened = lastOpened
            };
        }
        public async Task SaveStateAsync(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            // Create a dictionary to hold both SelectedFramework and ConceptualControls
            var saveData = new Dictionary<string, object>
    {
        { "SelectedFramework", SelectedFramework },
        { "ConceptualControls", ConceptualControls }
    };

            // Serialize the dictionary to JSON
            string json = JsonSerializer.Serialize(saveData, options);

            // Write the JSON to a file
            await File.WriteAllTextAsync(filePath, json);

            // Add the file to recent files
            var recent = CreateRecentFile(filePath);
            _recentFilesManager.AddRecentFile(recent);
        }

        public async Task LoadStateAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Error: Attempted to open file with empty filepath.");
                return;
            }
            string json = await File.ReadAllTextAsync(filePath);
            var loadedData = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (loadedData != null && loadedData.ContainsKey("SelectedFramework") && loadedData.ContainsKey("ConceptualControls"))
            {
                var validFrameworks = new List<string>
        {
            "DoDI 8510.01",
            "NIST SP 800.53 Rev. 5",
            "NIST SP 800-37 Rev. 2",
            "NIST SP 800-160 Vol. 1"
        };

                var jsonFramework = loadedData["SelectedFramework"]?.ToString();

                if (!validFrameworks.Contains(jsonFramework))
                {
                    MessageBox.Show($"Error: Invalid or unsupported framework '{jsonFramework}'.");
                    return; // TODO do something here so that if open fails it does not load empty dashboard
                }
                SelectedFramework = jsonFramework;

                // Retrieve and update the ConceptualControls
                var loadedControls = JsonSerializer.Deserialize<ObservableCollection<ConceptualCheckBox>>(loadedData["ConceptualControls"].ToString());

                if (loadedControls != null)
                {
                    ConceptualControls.Clear();
                    foreach (var control in loadedControls)
                    {
                        ConceptualControls.Add(control);
                    }

                    // Assign the first 29 controls to individual properties
                    ConceptualControl1 = loadedControls.ElementAtOrDefault(0);
                    ConceptualControl2 = loadedControls.ElementAtOrDefault(1);
                    ConceptualControl3 = loadedControls.ElementAtOrDefault(2);
                    ConceptualControl4 = loadedControls.ElementAtOrDefault(3);
                    ConceptualControl5 = loadedControls.ElementAtOrDefault(4);
                    ConceptualControl6 = loadedControls.ElementAtOrDefault(5);
                    ConceptualControl7 = loadedControls.ElementAtOrDefault(6);
                    ConceptualControl8 = loadedControls.ElementAtOrDefault(7);
                    ConceptualControl9 = loadedControls.ElementAtOrDefault(8);
                    ConceptualControl10 = loadedControls.ElementAtOrDefault(9);
                    ConceptualControl11 = loadedControls.ElementAtOrDefault(10);
                    ConceptualControl12 = loadedControls.ElementAtOrDefault(11);
                    ConceptualControl13 = loadedControls.ElementAtOrDefault(12);
                    ConceptualControl14 = loadedControls.ElementAtOrDefault(13);
                    ConceptualControl15 = loadedControls.ElementAtOrDefault(14);
                    ConceptualControl16 = loadedControls.ElementAtOrDefault(15);
                    ConceptualControl17 = loadedControls.ElementAtOrDefault(16);
                    ConceptualControl18 = loadedControls.ElementAtOrDefault(17);
                    ConceptualControl19 = loadedControls.ElementAtOrDefault(18);
                    ConceptualControl20 = loadedControls.ElementAtOrDefault(19);
                    ConceptualControl21 = loadedControls.ElementAtOrDefault(20);
                    ConceptualControl22 = loadedControls.ElementAtOrDefault(21);
                    ConceptualControl23 = loadedControls.ElementAtOrDefault(22);
                    ConceptualControl24 = loadedControls.ElementAtOrDefault(23);
                    ConceptualControl25 = loadedControls.ElementAtOrDefault(24);
                    ConceptualControl26 = loadedControls.ElementAtOrDefault(25);
                    ConceptualControl27 = loadedControls.ElementAtOrDefault(26);
                    ConceptualControl28 = loadedControls.ElementAtOrDefault(27);
                    ConceptualControl29 = loadedControls.ElementAtOrDefault(28);
                }
            }
            else
            {
                MessageBox.Show("Error: Invalid file format.");
            }
        }





        public void CreateNewFile(string framework)
        {
            SelectedFramework = framework;
            ConceptualControls.Clear(); //clears checkboxes so new one can be loaded
            switch (framework)
            {
                case "DoDI 8510.01":
                    LoadDoDICollection();
                    break;
                case "NIST SP 800.53 Rev. 5":
                    Load80053Collection();
                    break;
                case "NIST SP 800-37 Rev. 2":
                    Load80037Collection();
                    break;
                case "NIST SP 800-160 Vol. 1":
                    Load800160Collection();
                    break;
            }
            //TODO fix this so stack panel goes invisible
            ToggleRMFStackPanelVisibility();
        }
        private void RemoveFile(RecentFile recentFile)
        {
            if (recentFile != null)
            {
                RecentFiles.Remove(recentFile);
                _recentFilesManager.RemoveRecentFile(recentFile.FilePath);
            }
        }

        private async void OpenRecentFile(RecentFile recentFile)
        {
            string filePath = recentFile.FilePath;
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    await LoadStateAsync(filePath);
                    ToggleRMFStackPanelVisibility();
                    MessageBox.Show("File loaded successfully");
                }
                catch (Exception ex) { MessageBox.Show("$ex"); }

            }
            else
            {
                RemoveFile(recentFile);
                MessageBox.Show("Error: File path not found. Removing from recent files list.");
            }
        }
        public void LoadDoDICollection()
        {
            ConceptualControl1 = new ConceptualCheckBox
            {
                Severity = "Low/Low",
                CIA = "HHH",
                Name = "Conceptual Control 1",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 2",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 3",
                Severity = "High/High",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1"    , Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 4",
                Severity = "Med/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 5",
                Severity = "Low/Med",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl6 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 6",
                Severity = "High/High",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl7 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 7",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl8 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 8",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl9 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 9",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl10 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 10",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl11 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 11",
                Severity = "Low/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl12 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 12",
                Severity = "Med/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = false },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = false }
                }
            };
            ConceptualControl13 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 13",
                Severity = "Med/Low",
                CIA = "HHH",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl14 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 14",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl15 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 15",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl16 = new ConceptualCheckBox
            {
                Severity = "Med/Low",
                CIA = "LLL",
                Name = "Conceptual Control 16",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl17 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 17",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl18 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 18",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl19 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 19",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl20 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 20",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl21 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 21",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl22 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 22",
                Severity = "Med/Low",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl23 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 23",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl24 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 24",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl25 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 25",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };
            ConceptualControl26 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 26",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl27 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 27",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl28 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 28",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControl29 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 29",
                Severity = "High/High",
                CIA = "LLL",
                IsVisible = true,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = false },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = false }
    }
            };

            ConceptualControls = new ObservableCollection<ConceptualCheckBox>
            {
        ConceptualControl1, ConceptualControl2, ConceptualControl3, ConceptualControl4,
        ConceptualControl5, ConceptualControl6, ConceptualControl7, ConceptualControl8,
        ConceptualControl9, ConceptualControl10, ConceptualControl11, ConceptualControl12,
        ConceptualControl13, ConceptualControl14, ConceptualControl15, ConceptualControl16,
        ConceptualControl17, ConceptualControl18, ConceptualControl19, ConceptualControl20,
        ConceptualControl21, ConceptualControl22, ConceptualControl23, ConceptualControl24,
        ConceptualControl25, ConceptualControl26, ConceptualControl27, ConceptualControl28,
        ConceptualControl29
            };
            // Trigger the event to notify that the controls have been populated
            OnControlsPopulated?.Invoke();
        }


    }
}