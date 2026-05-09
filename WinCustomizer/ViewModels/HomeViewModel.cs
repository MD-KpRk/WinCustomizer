using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WinCustomizer.Models;

namespace WinCustomizer.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<MonitorInfo> _monitors;

        public HomeViewModel()
        {
            // TEST DATA
            _monitors = new ObservableCollection<MonitorInfo>
            {
                new MonitorInfo { Name = "Монитор 1 (Основной)", Resolution = "1920 x 1080" },
                new MonitorInfo { Name = "Монитор 2", Resolution = "2560 x 1440" },
                new MonitorInfo { Name = "Телевизор LG", Resolution = "3840 x 2160" }
            };
        }
    }
}