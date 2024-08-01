using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace SWAN.ViewModels
{
    public class TestViewModel : ObservableObject
    {
        private ObservableCollection<TestViewModel> _children;
        public ObservableCollection<TestViewModel> Children
        {
            get => _children;
            set => SetProperty(ref _children, value);
        }

        private string _label;
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (SetProperty(ref _isSelected, value))
                {
                    CheckChildSelected(value);
                }
            }
        }

        public TestViewModel(string label, bool isSelected = false)
        {
            Children = new ObservableCollection<TestViewModel>();
            Label = label;
            IsSelected = isSelected;
        }

        public TestViewModel() : this(string.Empty)
        {
        }

        public void AddChild(TestViewModel child)
        {
            Children.Add(child);
        }

        private void CheckChildSelected(bool value)
        {
            foreach (var child in Children)
            {
                child.IsSelected = value;
            }
        }
    }
}
