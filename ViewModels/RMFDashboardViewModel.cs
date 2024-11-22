using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.VisualBasic.FileIO;
using SWAN.Components;
using SWAN.Services;
using SWAN.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWAN.ViewModels
{
    public partial class RMFDashboardViewModel : ObservableObject

    {

        private readonly IMessenger _messenger;

        [ObservableProperty]
        private Visibility _RmfStackPanelVisibility = Visibility.Visible;

        [ObservableProperty]
        private Visibility checkBoxesVisibility = Visibility.Hidden;

        [ObservableProperty]
        public string selectedFramework = "Risk Management Framework Dashboard";

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

        [ObservableProperty]
        public ObservableCollection<ConceptualCheckBox> conceptualControls;

        [ObservableProperty]
        public UserControl checkBoxView;
        private int _checkBoxWidth;

        [ObservableProperty]
        public string fileName; //update this for all file operations


        private string _filePath;


       //make this one variable and just reassign it
        private UserControl Width1;
        private UserControl Width2;
        private UserControl Width3;
        private UserControl Width4;
        private UserControl Width5;
        public RMFDashboardViewModel(RecentFilesView fileView, IMessenger messenger, SettingsViewModel settings, ExpandableCheckBox4 width4, ExpandableCheckBox3 width3, ExpandableCheckBox1 width1, ExpandableCheckBox2 width2)
        {
            FileView = fileView;
            RecentFiles = new ObservableCollection<RecentFile>(_recentFilesManager.LoadRecentFiles());
            ConceptualControls = new ObservableCollection<ConceptualCheckBox>();
            _messenger = messenger;
            Width2 = width2;
            Width3 = width3;
            Width4 = width4;
            Width1 = width1;
            ConceptualControls.CollectionChanged += (s, e) =>
            {
                _messenger.Send(new ConceptualControlsUpdatedMessage(ConceptualControls));
            };
            int initialCheckBoxWidth = settings.CheckBoxesPerRow;
            UpdateCheckBoxView(initialCheckBoxWidth);
            //make this listen for the width being changed
            _messenger.Register<RMFDashboardViewModel, WidthUpdatedMessage>(this, (r, m) =>
            {
                r._checkBoxWidth = m.Value; // Save the file path
                r.UpdateCheckBoxView(_checkBoxWidth);
            });
        }

        private void UpdateCheckBoxView(int numPerRow)
        {
            switch (numPerRow)
            {
                case 1:
                    CheckBoxView = Width1;
                    break;
                case 2:
                    CheckBoxView = Width2;
                    break;
                case 3:
                    CheckBoxView = Width3;
                    break;
                case 4:
                    CheckBoxView = Width4;
                    break;
                default:
                    MessageBox.Show("Error: Invalid Number of CheckBoxes per Row.");
                    CheckBoxView = Width3;
                    break;
            }

            // Notify the UI that CheckBoxView has changed (if needed, depending on your data binding setup)
            OnPropertyChanged(nameof(CheckBoxView));
        }


        public ICommand LoadDoDICommand => new RelayCommand(LoadDoDICollection);
        public ICommand NewFileCommand => new RelayCommand<string>(CreateNewFile);
        public ICommand OpenRecentFileCommand => new RelayCommand<RecentFile>(OpenRecentFile);
        public ICommand RemoveFileCommand => new RelayCommand<RecentFile>(RemoveFile);

        //public ICommand SaveFileCommand => new RelayCommand<_>
        //make this a command to save the dashboard from the button



        // Example of changing visibility
        public void ToggleRMFStackPanelVisibility()
        {
            RmfStackPanelVisibility = Visibility.Hidden;
            CheckBoxesVisibility = Visibility.Visible;
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
            _filePath = filePath;
            FileName = Path.GetFileName(filePath);
        }

        public async Task<int> LoadStateAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Error: Attempted to open file with empty filepath.");
                return -1;
            }
            string json = await File.ReadAllTextAsync(filePath);
            var loadedData = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (loadedData != null && loadedData.ContainsKey("SelectedFramework") && loadedData.ContainsKey("ConceptualControls"))
            {
                var validFrameworks = new List<string>
        {
            "Software Assurance Overlay",
        };

                var jsonFramework = loadedData["SelectedFramework"]?.ToString();

                if (!validFrameworks.Contains(jsonFramework))
                {
                    MessageBox.Show($"Error: Invalid or unsupported framework '{jsonFramework}'.");
                    return -2; // TODO do something here so that if open fails it does not load empty dashboard
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
                if (SelectedFramework != "Software Assurance Overlay") //remove or change this to other func depending on selectedFramework
                {
                    InitUnusedCheckBoxes();
                }
                //updates the filepath in ScaffoldViewModel
                _messenger.Send(new FileOpenedMessage(filePath));
                _messenger.Send(new ConceptualControlsUpdatedMessage(ConceptualControls));
                ToggleRMFStackPanelVisibility();
                MessageBox.Show("File loaded successfully.");
                FileName = Path.GetFileName(filePath);
                return 0;
            }
            else
            {
                MessageBox.Show("Error: Invalid file format.");
                return -3;
            }
        }


        public void CreateNewFile(string framework)
        {
            SelectedFramework = framework;
            ConceptualControls.Clear(); //clears checkboxes so new one can be loaded
            LoadDoDICollection();
            ToggleRMFStackPanelVisibility();
            FileName = string.Empty;
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
                    _filePath = filePath;
                    FileName = Path.GetFileName(filePath);
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
                Severity = "Low - Low",
                CIA = "HHH",
                Name = "CM-1: Configuration Management Policy and Procedures",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall document the configuration management process directly or by reference in a Software Development Plan (SDP), Firmware Development Plan (FDP), or equivalent documents.", Passed = false },
                   
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "SA-3: System Development Life Cycle",
                Severity = "High - High",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall incorporate software/firmware security considerations into the SDLC.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document the secure SDLC directly or by reference in a SDP, FDP, Program Protection Implementation Plan (PPIP), or equivalent documents.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document software/firmware security roles and responsibilities directly or by reference in a SDP, FDP, PPIP, or equivalent documents.", Passed = false }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "SA-4: Acquisition Process",
                Severity = "High - High",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 2,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall document the software/firmware security requirements in a Software Requirements Specification or equivalent document."    , Passed = false },
                    new PhysicalControl { Control = "The developer shall provide, explicitly or by reference, a description of   the functional properties of the software/firmware security controls to be employed.", Passed = false },
                    
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "SA-4(2): Acquisition Process: Design/Implementation Information for Security Controls",
                Severity = "Mod - Mod",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall grant Government Purpose Rights for all delivered non- commercial and non-proprietary software/firmware.", Passed = false },
                    new PhysicalControl { Control = "The developer shall deliver all developed source code, incorporated code (open source, commercial, or third-party developed code), and any other components needed to build the software/firmware, to the Government to support an independent Government assessment of the code.", Passed = false },
                    new PhysicalControl { Control = "The developer shall provide detailed instructions to the Government for building the software/firmware using the delivered source code, incorporated code, and other software/firmware components.", Passed = false }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "SA-4(3): Acquisition Process: Development",
                Severity = "Mod - Mod",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 2,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall document software/firmware security engineering methods, software/firmware development methods, testing/evaluation/validation techniques, and quality control processes directly or by reference in a SDP, FDP, PPIP, or equivalent documents.", Passed = false },
                    new PhysicalControl { Control = "The developer shall incorporate software and firmware requirements from applicable Defense Information Systems Agency Security Technical Implementation Guides (STIG) (e.g., Application Security and Development STIG).", Passed = false },
                    
                }
            };
            ConceptualControl6 = new ConceptualCheckBox
            {
                Name = "SA-8: Security Engineering Principles",
                Severity = "Mod - Mod",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall apply software/firmware security engineering principles in the specification, design, development, implementation, and modification of system software and firmware.", Passed = false },
                    
                }
            };
            ConceptualControl7 = new ConceptualCheckBox
            {
                Name = "SA-10: Developer Configuration Management",
                Severity = "Mod - Mod",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 7,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall execute configuration management of software and firmware configuration items.", Passed = false },
                    new PhysicalControl { Control = "The developer shall identify software/firmware configuration items to be placed under configuration management. This shall include all developed source code, incorporated code (open source, commercial, or third-party developed code), and build and test environment software (compilers, libraries, build scripts).", Passed = false },
                    new PhysicalControl { Control = "The developer shall document, manage, and control the integrity of changes to software/firmware configuration items under configuration management.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document and utilize a process for approving changes to software/firmware configuration items.", Passed = false },
                    new PhysicalControl { Control = "The developer shall implement only approved changes to software/firmware configuration items.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document approved changes to software/firmware configuration items and the potential security impacts of such changes.", Passed = false },
                    new PhysicalControl { Control = "The developer shall make available to the Government upon request documentation describing the configuration items under configuration management including descriptions of the changes made to those configuration items.", Passed = false }
                }
            };
            ConceptualControl8 = new ConceptualCheckBox
            {
                Name = "SA-11: Developer Security Testing and Evaluation",
                Severity = "Moderate",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall verify software/firmware security requirements as a part of testing activities (unit testing, integration testing, software qualification testing, and system testing).Testing shall be automated as much as possible for efficiency and repeatability.", Passed = false },
                    new PhysicalControl { Control = "The developer shall produce evidence of the execution of software/firmware security requirements testing/evaluation in a Software Test Report, or equivalent document, provided to the Government upon request.", Passed = false },
                    new PhysicalControl { Control = "The developer shall manage all security flaws identified through software/firmware testing in accordance with the developer’s flaw remediation process.", Passed = false }
                }
            };
            ConceptualControl9 = new ConceptualCheckBox
            {
                Name = "SA-11(1): Developer Security Testing and Evaluation: Static Code Analysis",
                Severity = "High",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall employ source and binary static analysis tools to identify software/firmware weaknesses and vulnerabilities in developed and incorporated code (open source, commercial, or third-party developed code). Static Code Analysis tools shall be incorporated into the integrated development environment when possible.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document directly or by reference in a SDP, FDP, PPIP, or equivalent documents the specific source and binary static analysis tools to be employed. The Government shall evaluate the adequacy of these tools during the Government’s review of these documents.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document the detailed results of source and binary static analysis in a Software Assurance Evaluation Report (SAER) and summarize results in the Software Vulnerability Assessment Report (SVAR).", Passed = false }
                }
            };
            ConceptualControl10 = new ConceptualCheckBox
            {
                Name = "SA-11(2): Developer Security Testing and Evaluation: Threat and Vulnerability Analysis",
                Severity = "High",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 4,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall perform threat analysis to identify, quantify, and address the software and firmware security risks during the design and implementation phases of the SDLC.", Passed = false },
                    new PhysicalControl { Control = "The developer shall use threat modeling or similar processes to decompose the software/firmware, determine and rank threats, and determine countermeasures and mitigations.", Passed = false },
                    new PhysicalControl { Control = "The developer shall use threat information sources to ensure that software/firmware design and implementation accounts for threats early in the SDLC.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document threat analysis activities in a Software Threat Assessment Report (STAR) or equivalent document.", Passed = false }
                }
            };
            ConceptualControl11 = new ConceptualCheckBox
            {
                Name = "SA-11(3): Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence",
                Severity = "High",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 4,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall perform independent internal verification of developer software/firmware assessment plans and evidence. Developer personnel may perform this verification as long as independence is maintained. To maintain independence, the independent agent must be an entity that is not responsible for developing the product or performing the activity being evaluated.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document independence criteria directly or by reference in a SDP, FDP, test plan, or equivalent documents.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document independent internal verification of software/firmware assessment plans and evidence and shall provide to the Government upon request.", Passed = false },
                    new PhysicalControl { Control = "The developer shall ensure that the independent agent is provided with sufficient information to complete the verification process or granted the authority to obtain such information.", Passed = false }
                }
            };
            ConceptualControl12 = new ConceptualCheckBox
            {
                Name = "SA-11(4): Developer Security Testing and Evaluation: Manual Code Reviews",
                Severity = "Low - Low",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 2,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall use processes, procedures, and techniques to perform manual code reviews to identify weaknesses and vulnerabilities in software/firmware components. Manual code review activities shall include peer reviews of developed code, manual review of analysis tool results, and manual analysis of code that cannot be analyzed by analysis tools.", Passed = false },
                    new PhysicalControl { Control = "The developer shall document the detailed results of manual code reviews in a SAER, and summarize in the SVAR.", Passed = false }
                }
            };
            ConceptualControl13 = new ConceptualCheckBox
            {
                Name = "SA-11(5): Developer Security Testing and Evaluation: Penetration Testing/Analysis",
                Severity = "High",
                CIA = "HHH",
                IsVisible = true,
                FailedCount = 2,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall perform penetration and fuzz testing to identify software/firmware vulnerabilities in executable code.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the detailed results of penetration and fuzz testing activities in a SAER, and summarize in the SVAR.", Passed = false },
    }
            };

            ConceptualControl14 = new ConceptualCheckBox
            {
                Name = "SA-11(6): Developer Security Testing and Evaluation: Attack Surface Reviews",
                Severity = "High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall perform software/firmware attack surface analysis and reviews to identify and evaluate software/firmware attack vectors during the design and implementation phases of the SDLC.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the results of software/firmware attack surface analysis and reviews in a Software Attack Surface Analysis Report (SASAR).", Passed = false },
        new PhysicalControl { Control = "The developer shall conduct attack surface reduction activities based upon results of software/firmware attack surface analysis and reviews.", Passed = false }
    }
            };

            ConceptualControl15 = new ConceptualCheckBox
            {
                Name = "SA-11(7): Developer Security Testing and Evaluation: Verify Scope of Evaluation/Testing",
                Severity = "High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall verify that the scope of software/firmware security testing/evaluation provides complete coverage of software/firmware security requirements.", Passed = false }
    }
            };

            ConceptualControl16 = new ConceptualCheckBox
            {
                Severity = "High",
                CIA = "LLL",
                Name = "SA-11(8): Developer Security Testing and Evaluation: Dynamic Code Analysis",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall employ dynamic analysis tools to identify software/firmware weaknesses and vulnerabilities in developed and incorporated code (open source, commercial, or third-party developed code).", Passed = false },
        new PhysicalControl { Control = "The developer shall employ the following procedures as part of use/acceptance of incorporated code (open source, commercial, or third-party developed code):1)Incorporated code shall be analyzed for vulnerabilities using standard methods and tools.2)Incorporated code shall be implemented in a manner that supports security and product updates.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the detailed results of dynamic analysis in a SAER and summarize results in the SVAR.", Passed = false }
    }
            };

            ConceptualControl17 = new ConceptualCheckBox
            {
                Name = "SA-12: Supply Chain Protection",
                Severity = "High - High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall employ countermeasures to protect against software/firmware supply chain threats by implementing security safeguards as part of a comprehensive, information security strategy.", Passed = false },
        new PhysicalControl { Control = "The developer shall document software/firmware supply chain countermeasures in the PPIP or equivalent document.", Passed = false },
        new PhysicalControl { Control = "The developer shall employ tailored acquisition strategies, contract tools, and procurement methods for the purchase of software/firmware, software/firmware components, or software/firmware services from suppliers.", Passed = false }
    }
            };

            ConceptualControl18 = new ConceptualCheckBox
            {
                Name = "SA-12(5): Supply Chain Protection: Limitation of Harm",
                Severity = "Low",   
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall employ security safeguards to limit harm from potential adversaries identifying and targeting the organizational supply chain.", Passed = false },
    }
            };

            ConceptualControl19 = new ConceptualCheckBox
            {
                Name = "SA-12(8): Supply Chain Protection: Use of All-Source Intelligence",
                Severity = "Low",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall use all-source intelligence analysis of suppliers and potential suppliers of software/firmware, software/firmware components, or software/firmware services.", Passed = false }
    }
            };

            ConceptualControl20 = new ConceptualCheckBox
            {
                Name = "SA-12(9): Supply Chain Protection: Operations Security",
                Severity = "Low",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall employ OPSEC safeguards to be implemented in accordance with classification guides to protect supply chain-related information for software/firmware, software/firmware components, or software/firmware services.", Passed = false }
    }
            };

            ConceptualControl21 = new ConceptualCheckBox
            {
                Name = "SA-15: Development Process, Standards and Tools",
                Severity = "Mod - Mod",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall utilize a software/firmware development process that explicitly addresses software/firmware security requirements; implements secure coding standards; identifies the tools used in the development process; documents the specific tool options and configuration used in the development process; documents, manages, and ensures the integrity of changes to the process used for development.", Passed = false },
        new PhysicalControl { Control = "The developer shall employ the following procedures as part of use/acceptance of incorporated code (open source, commercial, or third-party developed code):1)Incorporated code shall be analyzed for vulnerabilities using standard methods and tools. 2)Incorporated code shall be implemented in a manner that supports security and product updates.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the detailed results of dynamic analysis in a SAER and summarize results in the SVAR.", Passed = false }
    }
            };

            ConceptualControl22 = new ConceptualCheckBox
            {
                Name = "SA-16: Development-Provided Training",
                Severity = "Low",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall ensure personnel are adequately trained on software/firmware security processes and considerations.", Passed = false }
    }
            };

            ConceptualControl23 = new ConceptualCheckBox
            {
                Name = "SA-17: Developer Security Architecture and Design",
                Severity = "High - High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 2,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall implement a software/firmware security architecture and design that provides the required security functionality; allocates security controls among physical and logical components; and integrates individual security functions, mechanisms, and services together to provide required security capabilities and a unified approach to protection.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the software/firmware security architecture and design information in the Architecture Design Document, Software Design Document, System/Subsystem Design Description, or equivalent documents. This shall include: Security-relevant external system interfaces, High-level design, Low-level design, Design/implementation information", Passed = false },
        
    }
            };

            ConceptualControl24 = new ConceptualCheckBox
            {
                Name = "SA-22: Developer Security Architecture and Design",
                Severity = "High - High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "The developer shall provide justification and document approval for the continued use of any unsupported software / firmware components required to satisfy mission / business needs.", Passed = false },
    }
    };

            ConceptualControl25 = new ConceptualCheckBox
            {
                Name = "SI-2: Flaw Remediation",
                Severity = "Mod - Mod",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 6,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = " The developer shall implement a flaw remediation process to identify, report, and manage all software and firmware flaws.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the flaw remediation process directly or by reference in a SDP, FDP, or equivalent documents.", Passed = false },
        new PhysicalControl { Control = "The developer shall manage all software/firmware vulnerabilities identified through source and binary static analysis in accordance with the developer’s flaw remediation process.", Passed = false },
        new PhysicalControl { Control = "The developer shall address all identified software weaknesses and vulnerabilities. If a weakness is determined to be an exploitable vulnerability, the developer must correct the software/firmware to eliminate the vulnerability, mitigate the vulnerability by other means, or document and manage the risk associated with the vulnerability.", Passed = false },
        new PhysicalControl { Control = "The developer shall test/regression-test software and firmware updates related to flaw remediation for effectiveness and potential side effects before installation.", Passed = false },
        new PhysicalControl { Control = "The developer shall manage and incorporate flaw remediation into the organizational configuration management process.", Passed = false },
    }
            };
            ConceptualControl26 = new ConceptualCheckBox
            {
                Name = "SI-2: Flaw Remediation: Time to Remediate Flaws/Benchmarks for Corrective Actions",
                Severity = "Moderate",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall collect metrics related to flaw identification and flaw remediation and shall make available to the Government upon request.", Passed = false },
    }
            };

            ConceptualControl27 = new ConceptualCheckBox
            {
                Name = "SI-3: Malicious Code Protection",
                Severity = "High - High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 3,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall employ malicious code protection mechanisms for the development environment and support malicious code protection for the deployed system.", Passed = false },
        new PhysicalControl { Control = "The developer shall document malicious code protection mechanisms in a PPIP or equivalent document.", Passed = false },
        new PhysicalControl { Control = "The developer shall update malicious code protection mechanisms whenever new releases are available in accordance with organizational configuration management policy and procedures.", Passed = false }
    }
            };

            ConceptualControl28 = new ConceptualCheckBox
            {
                Name = " SI-3(10): Malicious Code Protection: Malicious Code Analysis",
                Severity = "Very High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 1,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall analyze the characteristics and behavior of malicious code and shall incorporate the results of analysis into incident response and flaw remediation processes.", Passed = false },
    }
            };

            ConceptualControl29 = new ConceptualCheckBox
            {
                Name = "SI-7: Software, Firmware, and Information Integrity",
                Severity = "Very High - Very High",
                CIA = "LLL",
                IsVisible = true,
                FailedCount = 2,
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "The developer shall employ integrity verification processes to detect unauthorized changes to software and firmware.", Passed = false },
        new PhysicalControl { Control = "The developer shall document the use of integrity verification processes directly or by reference in a SDP, FDP, PPIP, or equivalent documents.", Passed = false }
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
        }

        public void InitUnusedCheckBoxes()
        {
            ConceptualControl6 = new ConceptualCheckBox();
            ConceptualControl7 = new ConceptualCheckBox();
            ConceptualControl8 = new ConceptualCheckBox();
            ConceptualControl9 = new ConceptualCheckBox();
            ConceptualControl10 = new ConceptualCheckBox();
            ConceptualControl11 = new ConceptualCheckBox();
            ConceptualControl12 = new ConceptualCheckBox();
            ConceptualControl13 = new ConceptualCheckBox();
            ConceptualControl14 = new ConceptualCheckBox();
            ConceptualControl15 = new ConceptualCheckBox();
            ConceptualControl16 = new ConceptualCheckBox();
            ConceptualControl17 = new ConceptualCheckBox();
            ConceptualControl18 = new ConceptualCheckBox();
            ConceptualControl19 = new ConceptualCheckBox();
            ConceptualControl20 = new ConceptualCheckBox();
            ConceptualControl21 = new ConceptualCheckBox();
            ConceptualControl22 = new ConceptualCheckBox();
            ConceptualControl23 = new ConceptualCheckBox();
            ConceptualControl24 = new ConceptualCheckBox();
            ConceptualControl25 = new ConceptualCheckBox();
            ConceptualControl26 = new ConceptualCheckBox();
            ConceptualControl27 = new ConceptualCheckBox();
            ConceptualControl28 = new ConceptualCheckBox();
            ConceptualControl29 = new ConceptualCheckBox();
        }
    }
}