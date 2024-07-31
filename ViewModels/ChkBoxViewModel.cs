using SWAN.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
    }
}
