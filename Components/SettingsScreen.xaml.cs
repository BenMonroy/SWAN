using SWAN.ViewModels;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace SWAN.Components
{
    /// <summary>
    /// Interaction logic for SettingsScreen.xaml
    /// </summary>
    public partial class SettingsScreen : UserControl
    {

        public SettingsScreen(SettingsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
