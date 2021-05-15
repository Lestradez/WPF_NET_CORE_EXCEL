using System.Windows.Controls;

using Iqui_WareHouse.ViewModels;

namespace Iqui_WareHouse.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage(SettingsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
