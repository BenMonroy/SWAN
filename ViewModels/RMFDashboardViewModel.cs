using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.FileIO;
using SWAN.Components;
using SWAN.Models;
using SWAN.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWAN.ViewModels
{
    public partial class RMFDashboardViewModel : ObservableObject

    {
        public ObservableCollection<CheckBoxItem> CheckBoxCollection { get; set; }
        
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




        public RMFDashboardViewModel(RecentFilesView fileView)
        {
            CheckBoxCollection = new ObservableCollection<CheckBoxItem>();
            FileView = fileView;
            RecentFiles = new ObservableCollection<RecentFile>(_recentFilesManager.LoadRecentFiles());
            
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

        public void DisposeCheckBoxCollection()
        {
            CheckBoxCollection.Clear();
        }

      

        private void Load80053Collection()
        {
            IList<CheckControl> controlList = new List<CheckControl> 
            { 
                new CheckControl { 
                    Major = "Placeholder for NIST SP 800.53 Rev. 5", Minor = "Nothing to see here" 
                } 
            };

            //take the list and adds them to the checkbox collection
            var groupedTests = controlList.GroupBy(t => t.Major);

            foreach (var group in groupedTests)
            {
                var parent = new CheckBoxItem(group.Key);
                foreach (var minorTest in group)
                {
                    parent.AddChild(new CheckBoxItem(minorTest.Minor));
                }
                CheckBoxCollection.Add(parent);
            }

        }

        private void Load80037Collection()
        {
            IList<CheckControl> controlList = new List<CheckControl>
            {
                new CheckControl {
                    Major = "Placeholder for NIST SP 800-37 Rev. 2", Minor = "Nothing to see here"
                }
            };

            //take the list and adds them to the checkbox collection
            var groupedTests = controlList.GroupBy(t => t.Major);

            foreach (var group in groupedTests)
            {
                var parent = new CheckBoxItem(group.Key);
                foreach (var minorTest in group)
                {
                    parent.AddChild(new CheckBoxItem(minorTest.Minor));
                }
                CheckBoxCollection.Add(parent);
            }

        }
        private void Load800160Collection()
        {
            IList<CheckControl> controlList = new List<CheckControl>
            {
                new CheckControl {
                    Major = "Placeholder for NIST SP 800-160 Vol. 1", Minor = "Nothing to see here"
                }
            };

            //take the list and adds them to the checkbox collection
            var groupedTests = controlList.GroupBy(t => t.Major);

            foreach (var group in groupedTests)
            {
                var parent = new CheckBoxItem(group.Key);
                foreach (var minorTest in group)
                {
                    parent.AddChild(new CheckBoxItem(minorTest.Minor));
                }
                CheckBoxCollection.Add(parent);
            }

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

        public void SaveStateToCsv(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            { MessageBox.Show("Error: Attempted to save file with empty filepath."); }
            var sb = new StringBuilder();
            //save the file to csv
            sb.AppendLine($"SelectedFramework,\"{SelectedFramework}\"");
            sb.AppendLine("Label,IsSelected");

            foreach (var test in CheckBoxCollection)
            {
                SaveTestToCsv(test, sb);
            }

            File.WriteAllText(filePath, sb.ToString());
            // add the file to recent files
            var recent = CreateRecentFile(filePath);
            _recentFilesManager.AddRecentFile(recent);
        }

        private void SaveTestToCsv(CheckBoxItem test, StringBuilder sb)
        {
            
            // Add quotes around the label to handle commas and special characters
            sb.AppendLine($"\"{EscapeCsvField(test.Label)}\",{test.IsSelected}");

            foreach (var child in test.Children)
            {
                SaveTestToCsv(child, sb);
            }
        }

        // Helper method to escape quotes in the CSV field
        private string EscapeCsvField(string field)
        {
            if (field.Contains("\""))
            {
                // Replace double quotes with two double quotes
                field = field.Replace("\"", "\"\"");
            }
            return field;
        }



        public void LoadStateFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.");
            //in case loading after already being in active file
            DisposeCheckBoxCollection();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Check the first line for SelectedFramework
                string[] firstLine = parser.ReadFields();
                if (firstLine.Length < 2 || firstLine[0] != "SelectedFramework")
                    throw new InvalidDataException("The CSV file does not start with 'SelectedFramework'.");

                // Validate the framework name in the second column
                string selectedFramework = firstLine[1];
                string[] validFrameworks = { "NIST SP 800-37 Rev. 2", "NIST SP 800-160 Vol. 1", "DoDI 8510.01", "NIST SP 800-53 Rev. 5" }; // Adjust according to your frameworks

                if (!validFrameworks.Contains(selectedFramework))
                    throw new InvalidDataException($"The specified framework '{selectedFramework}' is not recognized.");
                SelectedFramework = selectedFramework;

                // Read the header line
                string[] headers = parser.ReadFields();
                if (headers.Length < 2 || headers[0] != "Label" || headers[1] != "IsSelected")
                    throw new InvalidDataException("The CSV file does not have the correct header format.");

                switch (selectedFramework)
                {
                    case "DoDI 8510.01":
                        LoadDoDICollection();
                        break;
                    case "NIST SP 800-37 Rev. 2":
                        Load80037Collection();
                        break;
                    case "NIST SP 800-53 Rev. 5":
                        Load80053Collection();
                        break;
                    case "NIST SP 800-160 Vol. 1":
                        Load800160Collection();
                        break;
                }

                // Process each line after the header
                while (!parser.EndOfData)
                {
                    string[] columns = parser.ReadFields();

                    if (columns.Length < 2)
                        continue;

                    string label = columns[0];
                    bool isSelected = bool.Parse(columns[1]);

                    // Find the matching item in the collection by label
                    var matchingItem = CheckBoxCollection.FirstOrDefault(item => item.Label == label);

                    if (matchingItem != null)
                    {
                        matchingItem.IsSelected = isSelected;
                    }
                }

                ToggleRMFStackPanelVisibility();

            }
        }
        public void CreateNewFile(string framework)
        {
            SelectedFramework = framework;
            DisposeCheckBoxCollection(); //clears checkboxes so new one can be loaded
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

        private void OpenRecentFile(RecentFile recentFile)
        {
            string filePath = recentFile.FilePath;
            if (System.IO.File.Exists(filePath))
            {
                //open the file here
                LoadStateFromCsv(filePath);
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
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 2",
                Severity = "Low/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 3",
                Severity = "High/High",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1"    , Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 4", 
                Severity = "Med/Med",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 5", 
                Severity = "Low/Med",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl6 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 6", 
                Severity = "High/High",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl7 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 7", 
                Severity = "Low/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl8 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 8",
                Severity = "Low/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl9 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 9",
                Severity = "Low/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl10 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 10",
                Severity = "Low/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl11 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 11",
                Severity = "Low/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl12 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 12",
                Severity = "Med/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Passed = true }
                }
            };
            ConceptualControl13 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 13",
                Severity = "Med/Low",
                CIA = "HHH",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl14 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 14",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl15 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 15",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl16 = new ConceptualCheckBox
            {
                Severity = "Med/Low",
                CIA = "LLL",
                Name = "Conceptual Control 16",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl17 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 17",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl18 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 18",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl19 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 19",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl20 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 20",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl21 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 21",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl22 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 22",
                Severity = "Med/Low",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl23 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 23",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl24 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 24",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl25 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 25",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };
            ConceptualControl26 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 26",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl27 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 27",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl28 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 28",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };

            ConceptualControl29 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 29",
                Severity = "High/High",
                CIA = "LLL",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Passed = true }
    }
            };
        }


    }
}

