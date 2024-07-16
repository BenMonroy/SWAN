using System.Windows; // Ensure using WPF namespaces
using System.Windows.Controls;

namespace SWAN
{
    public partial class ResponsiveLayout : Page
    {
        public ResponsiveLayout()
        {
            InitializeComponent();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Handle size changes if needed
        }
    }
}
