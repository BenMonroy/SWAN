using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPTest
{
    public sealed partial class HorizontalSections : UserControl
    {
        public HorizontalSections()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(HorizontalSections), new PropertyMetadata(null));

        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MainProperty = DependencyProperty.Register("Main", typeof(object), typeof(HorizontalSections), new PropertyMetadata(null));

        public object Main
        {
            get { return GetValue(MainProperty); }
            set { SetValue(MainProperty, value); }
        }

        public static readonly DependencyProperty StuffProperty = DependencyProperty.Register("Stuff", typeof(object), typeof(HorizontalSections), new PropertyMetadata(null));

        public object Stuff
        {
            get { return GetValue(StuffProperty); }
            set { SetValue(StuffProperty, value); }
        }
    }
}
