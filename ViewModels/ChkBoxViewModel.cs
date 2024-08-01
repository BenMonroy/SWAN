using SWAN.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace SWAN.ViewModels
{
    public class ChkBoxViewModel
    {
        public ObservableCollection<TestViewModel> TestsCollection { get; set; }

        public ChkBoxViewModel()
        {
            LoadTestsCollection();
        }

        public void LoadTestsCollection()
        {
            IList<Test> testList = new List<Test>
{
    new Test { Major = "CM-1 - Configuration Management Policy and Procedures", Minor = "The developer shall document the configuration management process directly or by reference in a Software Development Plan (SDP), Firmware Development Plan (FDP), or equivalent documents. Maps to CCI-000287" },

    new Test { Major = "SA-3 - System Development Life Cycle", Minor = "The developer shall incorporate software/firmware security considerations into the SDLC. Maps to CCI-000615." },
    new Test { Major = "SA-3 - System Development Life Cycle", Minor = "The developer shall document the secure SDLC directly or by reference in a SDP, FDP, Program Protection Implementation Plan (PPIP), or equivalent documents. Maps to CCI-003092." },
    new Test { Major = "SA-3 - System Development Life Cycle", Minor = "The developer shall document software/firmware security roles and responsibilities directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-000616, CCI-000618." },

    new Test { Major = "SA-4 - Acquisition Process", Minor = "The developer shall document the software/firmware security requirements in a Software Requirements Specification or equivalent document. Maps to CCI-003095, CCI-003096." },
    new Test { Major = "SA-4 - Acquisition Process", Minor = "The developer shall provide, explicitly or by reference, a description of the functional properties of the software/firmware security controls to be employed. Maps to CCI-003094." },

    new Test { Major = "SA-4(2) - Acquisition Process: Design/Implementation Information for Security Controls", Minor = "The developer shall grant Government Purpose Rights for all delivered non-commercial and non-proprietary software/firmware. {Does not map to any CCI(s)}" },
    new Test { Major = "SA-4(2) - Acquisition Process: Design/Implementation Information for Security Controls", Minor = "The developer shall deliver all developed source code, incorporated code (open source, commercial, or third-party developed code), and any other components needed to build the software/firmware, to the Government to support an independent Government assessment of the code. Maps to CCI-003101, CCI-003102. {Related to SA-17.2}" },
    new Test { Major = "SA-4(2) - Acquisition Process: Design/Implementation Information for Security Controls", Minor = "The developer shall provide detailed instructions to the Government for building the software/firmware using the delivered source code, incorporated code, and other software/firmware components. Maps to CCI-003101, CCI-003102." },

    new Test { Major = "SA-4(3) - Acquisition Process: Development Methods/Techniques/Practices", Minor = "The developer shall document software/firmware security engineering methods, software/firmware development methods, testing/evaluation/validation techniques, and quality control processes directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-003108. {Previously this was mapped to SA-3.4}" },
    new Test { Major = "SA-4(3) - Acquisition Process: Development Methods/Techniques/Practices", Minor = "The developer shall incorporate software and firmware requirements from applicable Defense Information Systems Agency Security Technical Implementation Guides (STIG) (e.g., Application Security and Development STIG). Maps to CCI-003107, CCI-003108. {Previously this was mapped to SA-4.}" },

    new Test { Major = "SA-8 - Security Engineering Principles", Minor = "The developer shall apply software/firmware security engineering principles in the specification, design, development, implementation, and modification of system software and firmware. Maps to CCI-000664, 000665, 000666, 000667, 000668. {Previously this was mapped to SA-3.5}" },

    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall execute configuration management of software and firmware configuration items. Maps to CCI-003155." },
    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall identify software/firmware configuration items to be placed under configuration management. This shall include all developed source code, incorporated code (open source, commercial, or third-party developed code), and build and test environment software (compilers, libraries, build scripts). Maps to CCI-003159." },
    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall document, manage, and control the integrity of changes to software/firmware configuration items under configuration management. Maps to CCI-003156, CCI-003157, CCI-003158." },
    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall document and utilize a process for approving changes to software/firmware configuration items. Maps to CCI-003159." },
    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall implement only approved changes to software/firmware configuration items. Maps to CCI-000692." },
    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall document approved changes to software/firmware configuration items and the potential security impacts of such changes. Maps to CCI-000694, CCI-003160." },
    new Test { Major = "SA-10 - Developer Configuration Management", Minor = "The developer shall make available to the Government upon request documentation describing the configuration items under configuration management including descriptions of the changes made to those configuration items. Maps to CCI-003162." },

    new Test { Major = "SA-11 - Developer Security Testing and Evaluation", Minor = "The developer shall verify software/firmware security requirements as a part of testing activities (unit testing, integration testing, software qualification testing, and system testing). Testing shall be automated as much as possible for efficiency and repeatability. Maps to CCI-003173, CCI-003174." },
    new Test { Major = "SA-11 - Developer Security Testing and Evaluation", Minor = "The developer shall produce evidence of the execution of software/firmware security requirements testing/evaluation in a Software Test Report, or equivalent document, provided to the Government upon request. Maps to CCI-003175, CCI-003176." },
    new Test { Major = "SA-11 - Developer Security Testing and Evaluation", Minor = "The developer shall manage all security flaws identified through software/firmware testing in accordance with the developer’s flaw remediation process. Maps to CCI-003177, CCI-003178." },

    new Test { Major = "SA-11(1) - Developer Security Testing and Evaluation: Static Code Analysis", Minor = "The developer shall employ source and binary static analysis tools to identify software/firmware weaknesses and vulnerabilities in developed and incorporated code (open source, commercial, or third-party developed code). Static Code Analysis tools shall be incorporated into the integrated development environment when possible. Maps to CCI-003179. {Related to SA-12.4}" },
    new Test { Major = "SA-11(1) - Developer Security Testing and Evaluation: Static Code Analysis", Minor = "The developer shall document directly or by reference in a SDP, FDP, PPIP, or equivalent documents the specific source and binary static analysis tools to be employed. The Government shall evaluate the adequacy of these tools during the Government’s review of these documents. Maps to CCI-003180. {Related to SA-15, CCI-003233, 003234, 003235, 003236, 003237, 003238, 003239, 003240}" },
    new Test { Major = "SA-11(1) - Developer Security Testing and Evaluation: Static Code Analysis", Minor = "The developer shall document the detailed results of source and binary static analysis in a Software Assurance Evaluation Report (SAER) and summarize results in the Software Vulnerability Assessment Report (SVAR). Maps to CCI-003180 and Contract Data Requirements List (CDRL) SAER and SVAR." },

    new Test { Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall perform threat analysis to identify, quantify, and address the software and firmware security risks during the design and implementation phases of the SDLC. Maps to CCI-003181." },
    new Test { Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall use threat modeling or similar processes to decompose the software/firmware, determine and rank threats, and determine countermeasures and mitigations. Maps to CCI-003181, 003182. {Related to SA-15(4).5, CCI-003260}" },
    new Test { Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall use threat information sources to ensure that software/firmware design and implementation accounts for threats early in the SDLC. Maps to CCI-003181, CCI-003182." },
    new Test { Major = "SA-11(2) - Developer Security Testing and Evaluation: Threat and Vulnerability Analysis", Minor = "The developer shall document threat analysis activities in a Software Threat Assessment Report (STAR) or equivalent document. Maps to CCI-003181, CCI-003182 and CDRL for STAR." },

    new Test { Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall perform independent internal verification of developer software/firmware assessment plans and evidence. Developer personnel may perform this verification as long as independence is maintained. To maintain independence, the independent agent must be an entity that is not responsible for developing the product or performing the activity being evaluated. Maps to CCI-003183, CCI-003184." },
    new Test { Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall document independence criteria directly or by reference in a SDP, FDP, test plan, or equivalent documents. Maps to CCI-003185." },
    new Test { Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall document independent internal verification of software/firmware assessment plans and evidence and shall provide to the Government upon request. Maps to CCI-003184." },
    new Test { Major = "SA-11(3) - Developer Security Testing and Evaluation: Independent Verification of Assessment Plans/Evidence", Minor = "The developer shall ensure that the independent agent is provided with sufficient information to complete the verification process or granted the authority to obtain such information. Maps to CCI-003186." },

    new Test { Major = "SA-11(4) - Developer Security Testing and Evaluation: Manual Code Reviews", Minor = "The developer shall use processes, procedures, and techniques to perform manual code reviews to identify weaknesses and vulnerabilities in software/firmware components. Manual code review activities shall include peer reviews of developed code, manual review of analysis tool results, and manual analysis of code that cannot be analyzed by analysis tools. Maps to CCI-003189." },
    new Test { Major = "SA-11(4) - Developer Security Testing and Evaluation: Manual Code Reviews", Minor = "The developer shall document the detailed results of manual code reviews in a SAER, and summarize in the SVAR. Maps to CCI-003189 and CDRLs for SAER and SVAR." },

    new Test { Major = "SA-11(5) - Developer Security Testing and Evaluation: Penetration Testing/Analysis", Minor = "The developer shall perform penetration and fuzz testing to identify software/firmware vulnerabilities in executable code. Maps to CCI-003190, CCI-003191, CCI-003192." },
    new Test { Major = "SA-11(5) - Developer Security Testing and Evaluation: Penetration Testing/Analysis", Minor = "The developer shall document the detailed results of penetration and fuzz testing activities in a SAER, and summarize in the SVAR. Maps to CDRLs SAER and SVAR." },

    new Test { Major = "SA-11(6) - Developer Security Testing and Evaluation: Attack Surface Reviews", Minor = "The developer shall perform software/firmware attack surface analysis and reviews to identify and evaluate software/firmware attack vectors during the design and implementation phases of the SDLC. Maps to CCI-003193." },
    new Test { Major = "SA-11(6) - Developer Security Testing and Evaluation: Attack Surface Reviews", Minor = "The developer shall document the results of software/firmware attack surface analysis and reviews in a Software Attack Surface Analysis Report (SASAR). Maps to CDRL SASAR." },
    new Test { Major = "SA-11(6) - Developer Security Testing and Evaluation: Attack Surface Reviews", Minor = "The developer shall conduct attack surface reduction activities based upon results of software/firmware attack surface analysis and reviews. Maps to CCI-003193." },

    new Test { Major = "SA-11(7) - Developer Security Testing and Evaluation: Verify Scope of Testing/Evaluation", Minor = "The developer shall verify that the scope of software/firmware security testing/evaluation provides complete coverage of software/firmware security requirements. Maps to CCI-003194, CCI-003195." },

    new Test { Major = "SA-11(8) - Developer Security Testing and Evaluation: Dynamic Code Analysis", Minor = "The developer shall employ dynamic analysis tools to identify software/firmware weaknesses and vulnerabilities in developed and incorporated code (open source, commercial, or third-party developed code). Maps to CCI-003196." },
    new Test { Major = "SA-11(8) - Developer Security Testing and Evaluation: Dynamic Code Analysis", Minor = "The developer shall employ the following procedures as part of use/acceptance of incorporated code (open source, commercial, or third-party developed code): Incorporated code shall be analyzed for vulnerabilities using standard methods and tools. Incorporated code shall be implemented in a manner that supports security and product updates. Maps to CCI-003196. {Previously this was mapped to SA-12.4}" },
    new Test { Major = "SA-11(8) - Developer Security Testing and Evaluation: Dynamic Code Analysis", Minor = "The developer shall document the detailed results of dynamic analysis in a SAER and summarize results in the SVAR. Maps to CCI-003197 and CDRLs SAER and SVAR." },

    new Test { Major = "SA-12 - Supply Chain Protection", Minor = "The developer shall employ countermeasures to protect against software/firmware supply chain threats by implementing security safeguards as part of a comprehensive, information security strategy. Maps to CCI-000723." },
    new Test { Major = "SA-12 - Supply Chain Protection", Minor = "The developer shall document software/firmware supply chain countermeasures in the PPIP or equivalent document. Maps to CCI-000722." },
    new Test { Major = "SA-12 - Supply Chain Protection", Minor = "The developer shall employ tailored acquisition strategies, contract tools, and procurement methods for the purchase of software/firmware, software/firmware components, or software/firmware services from suppliers. Maps to CCI-000723." },

    new Test { Major = "SA-12(5) - Supply Chain Protection: Limitation of Harm", Minor = "The developer shall employ security safeguards to limit harm from potential adversaries identifying and targeting the organizational supply chain. Maps to CCI-00320. {Previously this was mapped to SA-12.5}" },

    new Test { Major = "SA-12(8) - Supply Chain Protection: Use of All-Source Intelligence", Minor = "The developer shall use all-source intelligence analysis of suppliers and potential suppliers of software/firmware, software/firmware components, or software/firmware services. Maps to CCI-003205. {Previously this was mapped to SA-12.6}" },

    new Test { Major = "SA-12(9) - Supply Chain Protection: Operations Security", Minor = "The developer shall employ OPSEC safeguards to be implemented in accordance with classification guides to protect supply chain-related information for software/firmware, software/firmware components, or software/firmware services. Maps to CCI-003206. {Previously this was mapped to SA-12.7}" },

    new Test { Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall utilize a software/firmware development process that explicitly addresses software/firmware security requirements; implements secure coding standards; identifies the tools used in the development process; documents the specific tool options and configuration used in the development process; documents, manages, and ensures the integrity of changes to the process used for development. Maps to CCI-003233, CCI-003234, CCI-003235, CCI-003236, CCI-003237, CCI-003238, CCI-003239, CCI-003240." },
    new Test { Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall document the software/firmware development process directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-003233, 003238." },
    new Test { Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall document directly or by reference in a SDP, FDP, PPIP, or equivalent documents the specific static and dynamic analysis tools to be employed. The Government shall evaluate the adequacy of these tools during the Government’s review of these documents. Maps to CCI-003233, CCI-003234, CCI-003235, CCI-003236, CCI-003237, CCI-003238, CCI-003239, CCI-003240. {Previously this was mapped to SA-11(8)}" },
    new Test { Major = "SA-15 - Development Process, Standards, and Tools", Minor = "The developer shall review the development process, standards, tools, and tool options/configurations on a periodic basis to determine if security requirements are being satisfied. Maps to CCI-003241, CCI-003242, CCI-003243, CCI-003244." },

    new Test { Major = "SA-16 - Developer-Provided Training", Minor = "The developer shall ensure personnel are adequately trained on software/firmware security processes and considerations. Maps to CCI-003291, CCI-003292. {Previously this was mapped to SA-3.6, and related to AT-3(3)}" },

    new Test { Major = "SA-17 - Developer Security Architecture and Design", Minor = "The developer shall implement a software/firmware security architecture and design that provides the required security functionality; allocates security controls among physical and logical components; and integrates individual security functions, mechanisms, and services together to provide required security capabilities and a unified approach to protection. Maps to CCI-003293, CCI-003295, CCI-003296, CCI-003297." },
    new Test { Major = "SA-17 - Developer Security Architecture and Design", Minor = "The developer shall document the software/firmware security architecture and design information in the Architecture Design Document, Software Design Document, System/Subsystem Design Description, or equivalent documents. This shall include: Security-relevant external system interfaces, High-level design, Low-level design, Design/implementation information. Maps to CCI-003293, CCI-003294. {Related to SA-4(2) CCI-003101, 003102}" },

    new Test { Major = "SA-22 - Unsupported System Components", Minor = "The developer shall provide justification and document approval for the continued use of any unsupported software/firmware components required to satisfy mission/business needs. Maps to CCI-003375. {Previously this was mapped to SA-12.8}" },

    new Test { Major = "SI-2 - Flaw Remediations", Minor = "The developer shall implement a flaw remediation process to identify, report, and manage all software and firmware flaws. Maps to CCI-001225, CCI-001226." },
    new Test { Major = "SI-2 - Flaw Remediations", Minor = "The developer shall document the flaw remediation process directly or by reference in a SDP, FDP, or equivalent documents. Maps to CCI-001225, CCI-001226." },
    new Test { Major = "SI-2 - Flaw Remediations", Minor = "The developer shall manage all software/firmware vulnerabilities identified through source and binary static analysis in accordance with the developer’s flaw remediation process. Maps to CCI-001225, CCI-001226. {Previously this was mapped to SA-11(1).4}" },
    new Test { Major = "SI-2 - Flaw Remediations", Minor = "The developer shall address all identified software weaknesses and vulnerabilities. If a weakness is determined to be an exploitable vulnerability, the developer must correct the software/firmware to eliminate the vulnerability, mitigate the vulnerability by other means, or document and manage the risk associated with the vulnerability. Maps to CCI-001227." },
    new Test { Major = "SI-2 - Flaw Remediations", Minor = "The developer shall test/regression-test software and firmware updates related to flaw remediation for effectiveness and potential side effects before installation. Maps to CCI-001228, CCI-001229, CCI-002602, CCI-002603." },
    new Test { Major = "SI-2 - Flaw Remediations", Minor = "The developer shall manage and incorporate flaw remediation into the organizational configuration management process. Maps to CCI-001230." },

    new Test { Major = "SI-2(3) - Flaw Remediation: Time to Remediate Flaws/Benchmarks for Corrective Actions", Minor = "The developer shall collect metrics related to flaw identification and flaw remediation and shall make available to the Government upon request. Maps to CCI-001235. {Previously this was mapped to SI-2.6}" },

    new Test { Major = "SI-3 - Malicious Code Protection", Minor = "The developer shall employ malicious code protection mechanisms for the development environment and support malicious code protection for the deployed system. Maps to CCI-001241, CCI-001242, CCI-01243, CCI-001244, CCI-001245, CCI-002619, CCI-002620, CCI-002621, CCI-002622, CCI-002624." },
    new Test { Major = "SI-3 - Malicious Code Protection", Minor = "The developer shall document malicious code protection mechanisms in a PPIP or equivalent document. Maps to CCI-002619, CCI-002620." },
    new Test { Major = "SI-3 - Malicious Code Protection", Minor = "The developer shall update malicious code protection mechanisms whenever new releases are available in accordance with organizational configuration management policy and procedures. Maps to CCI-001240, CCI-002623." },

    new Test { Major = "SI-3(10) - Malicious Code Protection: Malicious Code Analysis", Minor = "The developer shall analyze the characteristics and behavior of malicious code and shall incorporate the results of analysis into incident response and flaw remediation processes. Maps to CCI-002639, 002640. {Previously this was mapped to SI-3.}" },

    new Test { Major = "SI-7 - Software, Firmware, and Information Integrity", Minor = "The developer shall employ integrity verification processes to detect unauthorized changes to software and firmware. Maps to CCI-002704." },
    new Test { Major = "SI-7 - Software, Firmware, and Information Integrity", Minor = "The developer shall document the use of integrity verification processes directly or by reference in a SDP, FDP, PPIP, or equivalent documents. Maps to CCI-002703, CCI-002704." }
};


            TestsCollection = new ObservableCollection<TestViewModel>();

            var groupedTests = testList.GroupBy(t => t.Major);

            foreach (var group in groupedTests)
            {
                var parent = new TestViewModel(group.Key);
                foreach (var minorTest in group)
                {
                    parent.AddChild(new TestViewModel(minorTest.Minor));
                }
                TestsCollection.Add(parent);
            }
        }
        public void SaveStateToCsv(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Label,IsSelected");

            foreach (var test in TestsCollection)
            {
                SaveTestToCsv(test, sb);
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        private void SaveTestToCsv(TestViewModel test, StringBuilder sb)
        {
            sb.AppendLine($"{test.Label},{test.IsSelected}");
            foreach (var child in test.Children)
            {
                SaveTestToCsv(child, sb);
            }
        }

        public void LoadStateFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            var lines = File.ReadAllLines(filePath);
            var testMap = new Dictionary<string, TestViewModel>();

            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var parts = line.Split(',');
                var label = parts[0];
                var isSelected = bool.Parse(parts[1]);

                if (!testMap.ContainsKey(label))
                {
                    var test = new TestViewModel(label, isSelected);
                    testMap[label] = test;
                }
                else
                {
                    testMap[label].IsSelected = isSelected;
                }
            }

            // Rebuild the TestsCollection from the map
            TestsCollection = new ObservableCollection<TestViewModel>(testMap.Values);
        }
    }
}
