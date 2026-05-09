using System.Windows.Controls;
using WinCustomizer.ViewModels;

namespace WinCustomizer.Views.Pages
{
    public partial class HomePage : Page
    {
        public HomePage(HomeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}