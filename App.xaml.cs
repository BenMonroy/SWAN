using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SWAN.ViewModels;
using SWAN.Views;
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

        
                 services.AddSingleton<ScaffoldViewModel>();
                 services.AddSingleton<RiskScoreViewModel>();
                 services.AddSingleton<RMFDashboardViewModel>();
                 services.AddSingleton<IndexViewModel>();
                 services.AddSingleton<HistoryViewModel>();

                 services.AddSingleton<RecentFilesView>();
                 services.AddSingleton<HistoryView>();
                 services.AddSingleton<IndexView>();
                 services.AddSingleton<RiskScoreView>();
                 services.AddSingleton<RMFDashboardView>(); 
    
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
