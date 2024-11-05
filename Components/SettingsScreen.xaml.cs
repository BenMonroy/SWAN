using SWAN.ViewModels;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using SWAN.Services;
using CommunityToolkit.Mvvm.Messaging;

namespace SWAN.Components
{
    /// <summary>
    /// Interaction logic for SettingsScreen.xaml
    /// </summary>
    public partial class SettingsScreen : UserControl
    {
        private IMessenger _messenger;
        public SettingsScreen(SettingsViewModel viewModel, IMessenger messenger)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            _messenger = messenger;
        }

        public void CloseSettingsClick(object sender, RoutedEventArgs e)
        {
            _messenger.Send(new CloseSettingsButtonClickedMessage());
        }
    }
}
