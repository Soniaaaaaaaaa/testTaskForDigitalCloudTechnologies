using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using test202.Core;
using test202.MVVM.View;
using test202.MVVM.ViewModel;
using test202.Services;

namespace test202
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(ServiceProvider => new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainVM>()
            });

            services.AddSingleton<MainVM>();
            services.AddSingleton<HomeVM>();
            services.AddSingleton<DetailVM>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => ViewModelType => (ViewModel)serviceProvider.GetRequiredService(ViewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            var homeVM = _serviceProvider.GetRequiredService<HomeVM>();
            var homeView = new Home();
            homeView.DataContext = homeVM;

            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
