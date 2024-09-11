using SWAN.ViewModels;
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
    /// Interaction logic for DashboardNavigationBar.xaml
    /// </summary>
    public partial class DashboardNavigationBar : UserControl
    {
       
        public DashboardNavigationBar()
        {
            InitializeComponent();
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl tabControl && tabControl.SelectedItem is TabItem selectedTab)
            {
                if (selectedTab.Tag is PageId pageId)
                {
                    var viewModel = DataContext as ScaffoldViewModel;
                    viewModel?.ChangePageCommand.Execute(pageId);
                }
            }
        }

    }
}
