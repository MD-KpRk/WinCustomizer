using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WinCustomizer.ViewModels;
using WinCustomizer.Views.Pages;
using WinCustomizer.Views.Windows;
using Wpf.Ui;
using Wpf.Ui.DependencyInjection; // <- ВАЖНО: Добавляем пространство имен нового плагина

namespace WinCustomizer
{
    public partial class App : Application
    {
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Зампена старого IPageService
                services.AddNavigationViewPageProvider();

                // Стандартный сервис навигации
                services.AddSingleton<INavigationService, NavigationService>();

                // Главное окно
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();

                // Страницы и их ViewModels
                services.AddTransient<HomePage>();
                services.AddTransient<HomeViewModel>();

            }).Build();

        public static T GetService<T>() where T : class
            => _host.Services.GetRequiredService<T>();

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await _host.StartAsync();

            Wpf.Ui.Appearance.ApplicationThemeManager.Apply(
                Wpf.Ui.Appearance.ApplicationTheme.Dark
            );

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}