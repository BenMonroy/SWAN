using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace SWAN.ViewModels
{
    public class CheckBoxItem  : ObservableObject
    {
        private ObservableCollection<CheckBoxItem> _children;
        public ObservableCollection<CheckBoxItem> Children
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

        public CheckBoxItem(string label, bool isSelected = false)
        {
            Children = new ObservableCollection<CheckBoxItem>();
            Label = label;
            IsSelected = isSelected;
        }

        public CheckBoxItem() : this(string.Empty)
        {
        }

        public void AddChild(CheckBoxItem child)
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
