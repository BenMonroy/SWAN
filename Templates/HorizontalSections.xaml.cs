using System.Windows.Controls;

namespace SWAN
{
    public partial class HorizontalSections : UserControl
    {
        public HorizontalSections()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)TitlePresenter.Content;
            set => TitlePresenter.Content = value;
        }

        public object Main
        {
            get => MainPresenter.Content;
            set => MainPresenter.Content = value;
        }

        public object Stuff
        {
            get => StuffPresenter.Content;
            set => StuffPresenter.Content = value;
        }
    }
}
