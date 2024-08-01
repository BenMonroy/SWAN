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
                new Test { Major = "Configuration Management", Minor = "Policy and Procedures" },
                new Test { Major = "1", Minor = "2" },
                new Test { Major = "2", Minor = "1" },
                new Test { Major = "2", Minor = "2" },
                new Test { Major = "2", Minor = "3" },
                new Test { Major = "2", Minor = "18" },
                new Test { Major = "2", Minor = "36" }
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
