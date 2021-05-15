using System.Windows.Controls;

using Iqui_WareHouse.ViewModels;

namespace Iqui_WareHouse.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
