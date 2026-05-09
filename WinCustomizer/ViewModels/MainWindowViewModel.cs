using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WinCustomizer.Views.Pages;
using Wpf.Ui.Controls; 

namespace WinCustomizer.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "Windows Customizer BETA";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems;

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems;

        public MainWindowViewModel()
        {
            MenuItems = [
                new NavigationViewItem("Главная", SymbolRegular.Home24, typeof(HomePage)),
                new NavigationViewItem("Обои", SymbolRegular.Wallpaper24, typeof(HomePage)),
                new NavigationViewItem("Виджеты", SymbolRegular.Board24, typeof(HomePage))
            ];

            FooterMenuItems = [
                new NavigationViewItem("Настройки", SymbolRegular.Settings24, typeof(HomePage))
            ];
        }
    }
}