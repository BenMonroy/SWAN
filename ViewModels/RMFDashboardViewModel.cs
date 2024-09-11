﻿using CommunityToolkit.Mvvm.ComponentModel;
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

        public ConceptualCheckBox ConceptualControl1 { get; set; }
        public ConceptualCheckBox ConceptualControl2 { get; set; }
        public ConceptualCheckBox ConceptualControl3 { get; set; }
        public ConceptualCheckBox ConceptualControl4 { get; set; }
        public ConceptualCheckBox ConceptualControl5 { get; set; }
        public ConceptualCheckBox ConceptualControl6 { get; set; }
        public ConceptualCheckBox ConceptualControl7 { get; set; }
        public ConceptualCheckBox ConceptualControl8 { get; set; }
        public ConceptualCheckBox ConceptualControl9 { get; set; }
        public ConceptualCheckBox ConceptualControl10 { get; set; }
        public ConceptualCheckBox ConceptualControl11 { get; set; }
        public ConceptualCheckBox ConceptualControl12 { get; set; }
        public ConceptualCheckBox ConceptualControl13 { get; set; }
        public ConceptualCheckBox ConceptualControl14 { get; set; }
        public ConceptualCheckBox ConceptualControl15 { get; set; }
        public ConceptualCheckBox ConceptualControl16 { get; set; }
        public ConceptualCheckBox ConceptualControl17 { get; set; }
        public ConceptualCheckBox ConceptualControl18 { get; set; }
        public ConceptualCheckBox ConceptualControl19 { get; set; }
        public ConceptualCheckBox ConceptualControl20 { get; set; }
        public ConceptualCheckBox ConceptualControl21 { get; set; }
        public ConceptualCheckBox ConceptualControl22 { get; set; }
        public ConceptualCheckBox ConceptualControl23 { get; set; }
        public ConceptualCheckBox ConceptualControl24 { get; set; }
        public ConceptualCheckBox ConceptualControl25 { get; set; }
        public ConceptualCheckBox ConceptualControl26 { get; set; }
        public ConceptualCheckBox ConceptualControl27 { get; set; }
        public ConceptualCheckBox ConceptualControl28 { get; set; }
        public ConceptualCheckBox ConceptualControl29 { get; set; }



        public RMFDashboardViewModel(RecentFilesView fileView)
        {
            CheckBoxCollection = new ObservableCollection<CheckBoxItem>();
            FileView = fileView;
            RecentFiles = new ObservableCollection<RecentFile>(_recentFilesManager.LoadRecentFiles());
            // remove this after testing
            NewDoDIControls();

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

        private void LoadDoDICollection()
        {
            IList<CheckControl> controlList = new List<CheckControl>
{
    new CheckControl { Major = "CM-1 - Configuration Management Policy and Procedures", Minor = "The developer shall document the configuration management process directly or by reference in a Software Development Plan (SDP), Firmware Development Plan (FDP), or equivalent documents. Maps to CCI-000287" },

    new CheckControl { Major = "SA-3 - System Development Life Cycle", Minor = "The developer shall incorporate software/firmware security considerations into the SDLC. Maps to CCI-000615." },
    new CheckControl{ Major = "SA-3 - System Development Life Cycle", Minor = "The developer shall document the secure SDLC directly or by reference in a SDP, FDP, Program Protection Implementation Plan (PPIP), or equivalent documents. Maps to CCI-003092." },
    new CheckControl{ Major = "SA-3 - System Development Life Cycle", Minor = "The developer shall document software/firmware security roles and responsibilities directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-000616, CCI-000618." },

    new CheckControl { Major = "SA-4 - Acquisition Process", Minor = "The developer shall document the software/firmware security requirements in a Software Requirements Specification or equivalent document. Maps to CCI-003095, CCI-003096." },
    new CheckControl { Major = "SA-4 - Acquisition Process", Minor = "The developer shall provide, explicitly or by reference, a description of the functional properties of the software/firmware security controls to be employed. Maps to CCI-003094." },

    new CheckControl { Major = "SA-4(2) - Acquisition Process: Design/Implementation Information for Security Controls", Minor = "The developer shall grant Government Purpose Rights for all delivered non-commercial and non-proprietary software/firmware. {Does not map to any CCI(s)}" },
    new CheckControl { Major = "SA-4(2) - Acquisition Process: Design/Implementation Information for Security Controls", Minor = "The developer shall deliver all developed source code, incorporated code (open source, commercial, or third-party developed code), and any other components needed to build the software/firmware, to the Government to support an independent Government assessment of the code. Maps to CCI-003101, CCI-003102. {Related to SA-17.2}" },
    new CheckControl { Major = "SA-4(2) - Acquisition Process: Design/Implementation Information for Security Controls", Minor = "The developer shall provide detailed instructions to the Government for building the software/firmware using the delivered source code, incorporated code, and other software/firmware components. Maps to CCI-003101, CCI-003102." },

    new CheckControl { Major = "SA-4(3) - Acquisition Process: Development Methods/Techniques/Practices", Minor = "The developer shall document software/firmware security engineering methods, software/firmware development methods, testing/evaluation/validation techniques, and quality CheckControla processes directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-003108. {Previously this was mapped to SA-3.4}" },
    new CheckControl { Major = "SA-4(3) - Acquisition Process: Development Methods/Techniques/Practices", Minor = "The developer shall incorporate software and firmware requirements from applicable Defense Information Systems Agency Security Technical Implementation Guides (STIG) (e.g., Application Security and Development STIG). Maps to CCI-003107, CCI-003108. {Previously this was mapped to SA-4.}" },

    new CheckControl { Major = "SA-8 - Security Engineering Principles", Minor = "The developer shall apply software/firmware security engineering principles in the specification, design, development, implementation, and modification of system software and firmware. Maps to CCI-000664, 000665, 000666, 000667, 000668. {Previously this was mapped to SA-3.5}" },

    new CheckControl { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall execute configuration management of software and firmware configuration items. Maps to CCI-003155." },
    new CheckControl { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall identify software/firmware configuration items to be placed under configuration management. This shall include all developed source code, incorporated code (open source, commercial, or third-party developed code), and build and test environment software (compilers, libraries, build scripts). Maps to CCI-003159." },
    new CheckControl{ Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall document, manage, and CheckControl the integrity of changes to software/firmware configuration items under configuration management. Maps to CCI-003156, CCI-003157, CCI-003158." },
    new CheckControl { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall document and utilize a process for approving changes to software/firmware configuration items. Maps to CCI-003159." },
    new CheckControl { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall implement only approved changes to software/firmware configuration items. Maps to CCI-000692." },
    new CheckControl { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall document approved changes to software/firmware configuration items and the potential security impacts of such changes. Maps to CCI-000694, CCI-003160." },
    new CheckControl { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall make available to the Government upon request documentation describing the configuration items under configuration management including descriptions of the changes made to those configuration items. Maps to CCI-003162." },

    new CheckControl { Major = "SA-11 - Developer Security Testing and Evaluation", Minor = "The developer shall verify software/firmware security requirements as a part of testing activities (unit testing, integration testing, software qualification testing, and system testing). Testing shall be automated as much as possible for efficiency and repeatability. Maps to CCI-003173, CCI-003174." },
    new CheckControl { Major = "SA-11 - Developer Security Testing and Evaluation", Minor = "The developer shall produce evidence of the execution of software/firmware security requirements testing/evaluation in a Software Test Report, or equivalent document, provided to the Government upon request. Maps to CCI-003175, CCI-003176." },
    new CheckControl { Major = "SA-11 - Developer Security Testing and Evaluation", Minor = "The developer shall manage all security flaws identified through software/firmware testing in accordance with the developer’s flaw remediation process. Maps to CCI-003177, CCI-003178." },

    new CheckControl{ Major = "SA-11(1) - Developer Security Testing and Evaluation: Static Code Analysis", Minor = "The developer shall employ source and binary static analysis tools to identify software/firmware weaknesses and vulnerabilities in developed and incorporated code (open source, commercial, or third-party developed code). Static Code Analysis tools shall be incorporated into the integrated development environment when possible. Maps to CCI-003179. {Related to SA-12.4}" },
    new CheckControl{ Major = "SA-11(1) - Developer Security Testing and Evaluation: Static Code Analysis", Minor = "The developer shall document directly or by reference in a SDP, FDP, PPIP, or equivalent documents the specific source and binary static analysis tools to be employed. The Government shall evaluate the adequacy of these tools during the Government’s review of these documents. Maps to CCI-003180. {Related to SA-15, CCI-003233, 003234, 003235, 003236, 003237, 003238, 003239, 003240}" },
    new CheckControl{ Major = "SA-11(1) - Developer Security Testing and Evaluation: Static Code Analysis", Minor = "The developer shall document the detailed results of source and binary static analysis in a Software Assurance Evaluation Report (SAER) and summarize results in the Software Vulnerability Assessment Report (SVAR). Maps to CCI-003180 and Contract Data Requirements List (CDRL) SAER and SVAR." },

    new CheckControl{ Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall perform threat analysis to identify, quantify, and address the software and firmware security risks during the design and implementation phases of the SDLC. Maps to CCI-003181." },
    new CheckControl{ Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall use threat modeling or similar processes to decompose the software/firmware, determine and rank threats, and determine countermeasures and mitigations. Maps to CCI-003181, 003182. {Related to SA-15(4).5, CCI-003260}" },
    new CheckControl{ Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall use threat information sources to ensure that software/firmware design and implementation accounts for threats early in the SDLC. Maps to CCI-003181, CCI-003182." },
    new CheckControl{ Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall document threat analysis activities in a Software Threat Assessment Report (STAR) or equivalent document. Maps to CCI-003181, CCI-003182 and CDRL for STAR." },

    new CheckControl{ Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall perform independent internal verification of developer software/firmware assessment plans and evidence. Developer personnel may perform this verification as long as independence is maintained. To maintain independence, the independent agent must be an entity that is not responsible for developing the product or performing the activity being evaluated. Maps to CCI-003183, CCI-003184." },
    new CheckControl{ Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall document independence criteria directly or by reference in a SDP, FDP, test plan, or equivalent documents. Maps to CCI-003185." },
    new CheckControl{ Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall document independent internal verification of software/firmware assessment plans and evidence and shall provide to the Government upon request. Maps to CCI-003184." },
    new CheckControl{ Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall ensure that the independent agent is provided with sufficient information to complete the verification process or granted the authority to obtain such information. Maps to CCI-003186." },

    new CheckControl{ Major = "SA-11(4) - Developer Security Testing and Evaluation: Manual Code Reviews", Minor = "The developer shall use processes, procedures, and techniques to perform manual code reviews to identify weaknesses and vulnerabilities in software/firmware components. Manual code review activities shall include peer reviews of developed code, manual review of analysis tool results, and manual analysis of code that cannot be analyzed by analysis tools. Maps to CCI-003189." },
    new CheckControl{ Major = "SA-11(4) - Developer Security Testing and Evaluation: Manual Code Reviews", Minor = "The developer shall document the detailed results of manual code reviews in a SAER, and summarize in the SVAR. Maps to CCI-003189 and CDRLs for SAER and SVAR." },

    new CheckControl{ Major = "SA-11(5) - Developer Security Testing and Evaluation: Penetration Testing/Analysis", Minor = "The developer shall perform penetration and fuzz testing to identify software/firmware vulnerabilities in executable code. Maps to CCI-003190, CCI-003191, CCI-003192." },
    new CheckControl{ Major = "SA-11(5) - Developer Security Testing and Evaluation: Penetration Testing/Analysis", Minor = "The developer shall document the detailed results of penetration and fuzz testing activities in a SAER, and summarize in the SVAR. Maps to CDRLs SAER and SVAR." },

    new CheckControl{ Major = "SA-11(6) - Developer Security Testing and Evaluation: Attack Surface Reviews", Minor = "The developer shall perform software/firmware attack surface analysis and reviews to identify and evaluate software/firmware attack vectors during the design and implementation phases of the SDLC. Maps to CCI-003193." },
    new CheckControl{ Major = "SA-11(6) - Developer Security Testing and Evaluation: Attack Surface Reviews", Minor = "The developer shall document the results of software/firmware attack surface analysis and reviews in a Software Attack Surface Analysis Report (SASAR). Maps to CDRL SASAR." },
    new CheckControl{ Major = "SA-11(6) - Developer Security Testing and Evaluation: Attack Surface Reviews", Minor = "The developer shall conduct attack surface reduction activities based upon results of software/firmware attack surface analysis and reviews. Maps to CCI-003193." },

    new CheckControl{ Major = "SA-11(7) - Developer Security Testing and Evaluation: Verify Scope of Testing/Evaluation", Minor = "The developer shall verify that the scope of software/firmware security testing/evaluation provides complete coverage of software/firmware security requirements. Maps to CCI-003194, CCI-003195." },

    new CheckControl{ Major = "SA-11(8) - Developer Security Testing and Evaluation: Dynamic Code Analysis", Minor = "The developer shall employ dynamic analysis tools to identify software/firmware weaknesses and vulnerabilities in developed and incorporated code (open source, commercial, or third-party developed code). Maps to CCI-003196." },
    new CheckControl{ Major = "SA-11(8) - Developer Security Testing and Evaluation: Dynamic Code Analysis", Minor = "The developer shall employ the following procedures as part of use/acceptance of incorporated code (open source, commercial, or third-party developed code): Incorporated code shall be analyzed for vulnerabilities using standard methods and tools. Incorporated code shall be implemented in a manner that supports security and product updates. Maps to CCI-003196. {Previously this was mapped to SA-12.4}" },
    new CheckControl{ Major = "SA-11(8) - Developer Security Testing and Evaluation: Dynamic Code Analysis", Minor = "The developer shall document the detailed results of dynamic analysis in a SAER and summarize results in the SVAR. Maps to CCI-003197 and CDRLs SAER and SVAR." },

    new CheckControl{ Major = "SA-12 - Supply Chain Protection", Minor = "The developer shall employ countermeasures to protect against software/firmware supply chain threats by implementing security safeguards as part of a comprehensive, information security strategy. Maps to CCI-000723." },
    new CheckControl{ Major = "SA-12 - Supply Chain Protection", Minor = "The developer shall document software/firmware supply chain countermeasures in the PPIP or equivalent document. Maps to CCI-000722." },
    new CheckControl{ Major = "SA-12 - Supply Chain Protection", Minor = "The developer shall employ tailored acquisition strategies, contract tools, and procurement methods for the purchase of software/firmware, software/firmware components, or software/firmware services from suppliers. Maps to CCI-000723." },

    new CheckControl{ Major = "SA-12(5) - Supply Chain Protection: Limitation of Harm", Minor = "The developer shall employ security safeguards to limit harm from potential adversaries identifying and targeting the organizational supply chain. Maps to CCI-00320. {Previously this was mapped to SA-12.5}" },

    new CheckControl{ Major = "SA-12(8) - Supply Chain Protection: Use of All-Source Intelligence", Minor = "The developer shall use all-source intelligence analysis of suppliers and potential suppliers of software/firmware, software/firmware components, or software/firmware services. Maps to CCI-003205. {Previously this was mapped to SA-12.6}" },

    new CheckControl{ Major = "SA-12(9) - Supply Chain Protection: Operations Security", Minor = "The developer shall employ OPSEC safeguards to be implemented in accordance with classification guides to protect supply chain-related information for software/firmware, software/firmware components, or software/firmware services. Maps to CCI-003206. {Previously this was mapped to SA-12.7}" },

    new CheckControl{ Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall utilize a software/firmware development process that explicitly addresses software/firmware security requirements; implements secure coding standards; identifies the tools used in the development process; documents the specific tool options and configuration used in the development process; documents, manages, and ensures the integrity of changes to the process used for development. Maps to CCI-003233, CCI-003234, CCI-003235, CCI-003236, CCI-003237, CCI-003238, CCI-003239, CCI-003240." },
    new CheckControl{ Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall document the software/firmware development process directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-003233, 003238." },
    new CheckControl{ Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall document directly or by reference in a SDP, FDP, PPIP, or equivalent documents the specific static and dynamic analysis tools to be employed. The Government shall evaluate the adequacy of these tools during the Government’s review of these documents. Maps to CCI-003233, CCI-003234, CCI-003235, CCI-003236, CCI-003237, CCI-003238, CCI-003239, CCI-003240. {Previously this was mapped to SA-11(8)}" },
    new CheckControl{ Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall review the development process, standards, tools, and tool options/configurations on a periodic basis to determine if security requirements are being satisfied. Maps to CCI-003241, CCI-003242, CCI-003243, CCI-003244." },

    new CheckControl{ Major = "SA-16 - Developer-Provided Training", Minor = "The developer shall ensure personnel are adequately trained on software/firmware security processes and considerations. Maps to CCI-003291, CCI-003292. {Previously this was mapped to SA-3.6, and related to AT-3(3)}" },

    new CheckControl{ Major = "SA-17 - Developer Security Architecture and Design", Minor = "The developer shall implement a software/firmware security architecture and design that provides the required security functionality; allocates security controls among physical and logical components; and integrates individual security functions, mechanisms, and services together to provide required security capabilities and a unified approach to protection. Maps to CCI-003293, CCI-003295, CCI-003296, CCI-003297." },
    new CheckControl{ Major = "SA-17 - Developer Security Architecture and Design", Minor = "The developer shall document the software/firmware security architecture and design information in the Architecture Design Document, Software Design Document, System/Subsystem Design Description, or equivalent documents. This shall include: Security-relevant external system interfaces, High-level design, Low-level design, Design/implementation information. Maps to CCI-003293, CCI-003294. {Related to SA-4(2) CCI-003101, 003102}" },

    new CheckControl{ Major = "SA-22 - Unsupported System Components", Minor = "The developer shall provide justification and document approval for the continued use of any unsupported software/firmware components required to satisfy mission/business needs. Maps to CCI-003375. {Previously this was mapped to SA-12.8}" },

    new CheckControl{ Major = "SI-2 - Flaw Remediations", Minor = "The developer shall implement a flaw remediation process to identify, report, and manage all software and firmware flaws. Maps to CCI-001225, CCI-001226." },
    new CheckControl{ Major = "SI-2 - Flaw Remediations", Minor = "The developer shall document the flaw remediation process directly or by reference in a SDP, FDP, or equivalent documents. Maps to CCI-001225, CCI-001226." },
    new CheckControl{ Major = "SI-2 - Flaw Remediations", Minor = "The developer shall manage all software/firmware vulnerabilities identified through source and binary static analysis in accordance with the developer’s flaw remediation process. Maps to CCI-001225, CCI-001226. {Previously this was mapped to SA-11(1).4}" },
    new CheckControl{ Major = "SI-2 - Flaw Remediations", Minor = "The developer shall address all identified software weaknesses and vulnerabilities. If a weakness is determined to be an exploitable vulnerability, the developer must correct the software/firmware to eliminate the vulnerability, mitigate the vulnerability by other means, or document and manage the risk associated with the vulnerability. Maps to CCI-001227." },
    new CheckControl{ Major = "SI-2 - Flaw Remediations", Minor = "The developer shall test/regression-test software and firmware updates related to flaw remediation for effectiveness and potential side effects before installation. Maps to CCI-001228, CCI-001229, CCI-002602, CCI-002603." },
    new CheckControl{ Major = "SI-2 - Flaw Remediations", Minor = "The developer shall manage and incorporate flaw remediation into the organizational configuration management process. Maps to CCI-001230." },

    new CheckControl{ Major = "SI-2(3) - Flaw Remediation: Time to Remediate Flaws/Benchmarks for Corrective Actions", Minor = "The developer shall collect metrics related to flaw identification and flaw remediation and shall make available to the Government upon request. Maps to CCI-001235. {Previously this was mapped to SI-2.6}" },

    new CheckControl{ Major = "SI-3 - Malicious Code Protection", Minor = "The developer shall employ malicious code protection mechanisms for the development environment and support malicious code protection for the deployed system. Maps to CCI-001241, CCI-001242, CCI-01243, CCI-001244, CCI-001245, CCI-002619, CCI-002620, CCI-002621, CCI-002622, CCI-002624." },
    new CheckControl{ Major = "SI-3 - Malicious Code Protection", Minor = "The developer shall document malicious code protection mechanisms in a PPIP or equivalent document. Maps to CCI-002619, CCI-002620." },
    new CheckControl{ Major = "SI-3 - Malicious Code Protection", Minor = "The developer shall update malicious code protection mechanisms whenever new releases are available in accordance with organizational configuration management policy and procedures. Maps to CCI-001240, CCI-002623." },

    new CheckControl{ Major = "SI-3(10) - Malicious Code Protection: Malicious Code Analysis", Minor = "The developer shall analyze the characteristics and behavior of malicious code and shall incorporate the results of analysis into incident response and flaw remediation processes. Maps to CCI-002639, 002640. {Previously this was mapped to SI-3.}" },

    new CheckControl{ Major = "SI-7 - Software, Firmware, and Information Integrity", Minor = "The developer shall employ integrity verification processes to detect unauthorized changes to software and firmware. Maps to CCI-002704." },
    new CheckControl{ Major = "SI-7 - Software, Firmware, and Information Integrity", Minor = "The developer shall document the use of integrity verification processes directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-002703, CCI-002704." }
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
        public void NewDoDIControls()
        {
            ConceptualControl1 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 1",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl2 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 2",
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl3 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 3", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl4 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 4", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl5 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 5", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl6 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 6", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl7 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 7", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl8 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 8", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl9 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 9", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl10 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 10", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl11 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 11", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl12 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 12", // You can modify this name as needed
                PhysicalControls = new ObservableCollection<PhysicalControl>
                {
                    new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
                    new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
                    new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
                }
            };
            ConceptualControl13 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 13",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl14 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 14",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl15 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 15",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl16 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 16",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl17 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 17",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl18 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 18",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl19 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 19",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl20 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 20",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl21 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 21",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl22 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 22",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl23 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 23",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl24 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 24",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl25 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 25",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };
            ConceptualControl26 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 26",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl27 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 27",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl28 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 28",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };

            ConceptualControl29 = new ConceptualCheckBox
            {
                Name = "Conceptual Control 29",
                PhysicalControls = new ObservableCollection<PhysicalControl>
    {
        new PhysicalControl { Control = "Physical Control 1", Severity = "Low/Low", Passed = true },
        new PhysicalControl { Control = "Physical Control 2", Severity = "Med/Med", Passed = false },
        new PhysicalControl { Control = "Physical Control 3", Severity = "High/High", Passed = true }
    }
            };
        }


    }
}

