using SWAN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.ViewModels
{

    public class ChkBoxViewModel
    {
        public ObservableCollection<TestViewModel> TestsCollection { get; set; }

        public ChkBoxViewModel()
        {
            this.LoadTestsCollection();
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
            };

            TestsCollection = new ObservableCollection<TestViewModel>();
            TestViewModel parent = null;
            List<string> chckMajor = new List<string>();
            bool isInserted = false;

            foreach (var item in testList)
            {
                //New Major thus insert the previous value to parent
                if (isInserted && !chckMajor.Contains(item.Major))
                {
                    TestsCollection.Add(parent);
                }

                if (!chckMajor.Contains(item.Major))
                {
                    parent = new TestViewModel( item.Major.ToString());
                    chckMajor.Add(item.Major);
                    isInserted = true;
                }

                parent?.AddChild(new TestViewModel(item.Minor.ToString()));

                //Check last item
                int lastIndex = testList.Count - 1;
                int itemIndex = testList.IndexOf(item);

                if (itemIndex == lastIndex)
                    TestsCollection.Add(parent);
            }
        }
    }
}
