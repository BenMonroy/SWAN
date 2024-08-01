using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        public static IHost? AppHost { get; set; }

        public App()
        {

            AppHost = Host.CreateDefaultBuilder()
             .ConfigureServices((hostContext, services) => {
                 services.AddSingleton<MainWindow>();

             }).Build();

        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startupWindow = AppHost.Services.GetRequiredService<MainWindow>();
            startupWindow.Show(); 

            base.OnStartup(e);
        }
        
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
        

    }

}
