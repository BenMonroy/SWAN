using SWAN.ViewModels;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SWAN.Views
{
    public partial class IndexView : UserControl
    {
        public IndexView(IndexViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            LoadData();
        }

        private void LoadData()
        {
            var parent1 = new Parent("Parent #1")
            {
                ChildItems = {
                    new Child("Child Item #1.1"),
                    new Child("Child Item #1.2"),
                    new Child("Child Item #1.3")
                }
            };

            var parent2 = new Parent("Parent #2")
            {
                ChildItems = {
                    new Child("Child Item #2.1"),
                    new Child("Child Item #2.2"),
                    new Child("Child Item #2.3")
                }
            };

            List<Parent> parents = new List<Parent> { parent1, parent2 };
            treeView.ItemsSource = parents;
        }
    }

    public class Child
    {
        public Child(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
    }

    public class Parent
    {
        public Parent(string title)
        {
            Title = title;
            ChildItems = new List<Child>();
        }
        public string Title { get; set; }
        public List<Child> ChildItems { get; set; }
    }
}
