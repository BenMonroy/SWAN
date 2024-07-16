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
    /// Interaction logic for CheckboxComponent.xaml
    /// </summary>
    public partial class CheckboxComponent : UserControl
    {
        public CheckboxComponent()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CheckboxLabelProperty =
           DependencyProperty.Register("CheckboxLabel", typeof(string), typeof(CheckboxComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ThreeStateProperty =
            DependencyProperty.Register("ThreeState", typeof(string), typeof(CheckboxComponent), new PropertyMetadata(string.Empty));

        public string CheckboxLabel
        {
            get { return (string)GetValue(CheckboxLabelProperty); }
            set { SetValue(CheckboxLabelProperty, value); }
        }

        public string ThreeState
        {
            get { return (string)GetValue(ThreeStateProperty); }
            set { SetValue(ThreeStateProperty, value); }
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is checked.";
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is unchecked.";
        }

        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is in the indeterminate state.";
        }

    }
}