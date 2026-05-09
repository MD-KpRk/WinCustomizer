using System.Windows;
using WinCustomizer.ViewModels;
using WinCustomizer.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Controls; 

namespace WinCustomizer.Views.Windows
{
    public partial class MainWindow : FluentWindow
    {
        private readonly INavigationService _navigationService;

        public MainWindow(
            MainWindowViewModel viewModel,
            INavigationService navigationService,
            INavigationViewPageProvider pageProvider)
        {
            DataContext = viewModel;
            InitializeComponent();

            _navigationService = navigationService;
            RootNavigation.SetPageProviderService(pageProvider);
            _navigationService.SetNavigationControl(RootNavigation);

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(typeof(HomePage));
        }
    }
}