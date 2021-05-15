using System.Windows.Controls;

using Iqui_WareHouse.Contracts.Views;
using Iqui_WareHouse.ViewModels;

using MahApps.Metro.Controls;

namespace Iqui_WareHouse.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public Frame GetRightPaneFrame()
            => rightPaneFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        public SplitView GetSplitView()
            => splitView;
    }
}
