using SWAN.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SWAN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            ScaffoldViewModel viewModel = new ScaffoldViewModel();
            MainWindow.DataContext = viewModel;
            MainWindow.Show();

            base.OnStartup(e);
        }
        

    }

}
