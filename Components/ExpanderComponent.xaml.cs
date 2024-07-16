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
    public partial class ExpanderComponent : UserControl
    {
        public ExpanderComponent()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ColumnTitleProperty =
            DependencyProperty.Register("ColumnTitle", typeof(string), typeof(ExpanderComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ExpanderHeaderProperty =
            DependencyProperty.Register("ExpanderHeader", typeof(string), typeof(ExpanderComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ExpanderContentProperty =
            DependencyProperty.Register("ExpanderContent", typeof(string), typeof(ExpanderComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(BitmapImage), typeof(ExpanderComponent), new PropertyMetadata(null));

        public string ColumnTitle
        {
            get { return (string)GetValue(ColumnTitleProperty); }
            set { SetValue(ColumnTitleProperty, value); }
        }

        public string ExpanderHeader
        {
            get { return (string)GetValue(ExpanderHeaderProperty); }
            set { SetValue(ExpanderHeaderProperty, value); }
        }

        public string ExpanderContent
        {
            get { return (string)GetValue(ExpanderContentProperty); }
            set { SetValue(ExpanderContentProperty, value); }
        }

        public BitmapImage IconSource
        {
            get { return (BitmapImage)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }
    }
}

