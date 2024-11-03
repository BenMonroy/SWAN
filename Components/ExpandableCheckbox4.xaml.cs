using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWAN.Components
{
    /// <summary>
    /// Interaction logic for ExpandableCheckbox4.xaml
    /// </summary>
    public partial class ExpandableCheckBox4 : UserControl
    {
        public ExpandableCheckBox4()
        {
            InitializeComponent();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            var checkBox = sender as CheckBox;
            // Get the DataContext of the CheckBox, which is bound to PhysicalControl
            var dataContext = checkBox.DataContext as PhysicalControl;

            if (dataContext != null)
            {
                // Set the Passed property of the bound PhysicalControl to true
                dataContext.Passed = true;

                // Get the parent ConceptualCheckBox by traversing the visual tree
                var parentExpander = FindVisualParent<Expander>(checkBox);
                if (parentExpander == null) { MessageBox.Show("Parent control not found"); }
                if (parentExpander != null)
                {
                    var parentDataContext = parentExpander.DataContext;
                    var conceptualCheckBox = parentExpander.DataContext as ConceptualCheckBox;
                    if (conceptualCheckBox == null) { MessageBox.Show("Conceptual Checkbox not found"); }
                    if (conceptualCheckBox != null)
                    {
                        conceptualCheckBox.FailedCount = conceptualCheckBox.PhysicalControls.Count(pc => !pc.Passed);

                        // if all are passed set AllPassed to true
                        conceptualCheckBox.AllPassed = conceptualCheckBox.PhysicalControls.All(pc => pc.Passed);

                        //this is for testing, change this to be a style 
                        // if (conceptualCheckBox.AllPassed) {parentExpander.Background = Brushes.LightGreen; }
                        // if (!conceptualCheckBox.AllPassed) { parentExpander.Background = Brushes.Blue; }
                    }
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Cast sender as CheckBox
            var checkBox = sender as CheckBox;

            // Get the DataContext of the CheckBox, which is bound to PhysicalControl
            var dataContext = checkBox.DataContext as PhysicalControl;

            if (dataContext != null)
            {
                // Set the Passed property of the bound PhysicalControl to false
                dataContext.Passed = false;

                // Get the parent ConceptualCheckBox by traversing the visual tree
                var parentExpander = FindVisualParent<Expander>(checkBox);
                if (parentExpander != null)
                {
                    var conceptualCheckBox = parentExpander.DataContext as ConceptualCheckBox;
                    if (conceptualCheckBox != null)
                    {
                        conceptualCheckBox.AllPassed = false;
                        conceptualCheckBox.FailedCount = conceptualCheckBox.PhysicalControls.Count(pc => !pc.Passed);

                    }
                    //for testing remove this and switch to a style
                    //  if (!conceptualCheckBox.AllPassed) { parentExpander.Background = Brushes.Blue; };
                }
            }
        }


        private T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            while (child != null && !(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }
            return child as T;
        }
    }
}
