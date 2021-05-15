using System;
using System.Windows;
using System.Windows.Input;

using Iqui_WareHouse.Contracts.Services;
using Iqui_WareHouse.Properties;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Iqui_WareHouse.ViewModels
{
    // You can show pages in different ways (update main view, navigate, right pane, new windows or dialog)
    // using the NavigationService, RightPaneService and WindowManagerService.
    // Read more about MenuBar project type here:
    // https://github.com/Microsoft/WindowsTemplateStudio/blob/release/docs/WPF/projectTypes/menubar.md
    public class ShellViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IRightPaneService _rightPaneService;

        private RelayCommand _goBackCommand;
        private ICommand _menuFileSettingsCommand;
        private ICommand _menuViewsDataGridCommand;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuFileExitCommand;
        private ICommand _loadedCommand;
        private ICommand _unloadedCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand MenuFileSettingsCommand => _menuFileSettingsCommand ?? (_menuFileSettingsCommand = new RelayCommand(OnMenuFileSettings));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        public ShellViewModel(INavigationService navigationService, IRightPaneService rightPaneService)
        {
            _navigationService = navigationService;
            _rightPaneService = rightPaneService;
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded()
        {
            _rightPaneService.CleanUp();
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnNavigated(object sender, string viewModelName)
        {
            GoBackCommand.NotifyCanExecuteChanged();
        }

        private void OnMenuFileExit()
            => Application.Current.Shutdown();

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        private void OnMenuViewsMain()
            => _navigationService.NavigateTo(typeof(MainViewModel).FullName, null, true);

        public ICommand MenuViewsDataGridCommand => _menuViewsDataGridCommand ?? (_menuViewsDataGridCommand = new RelayCommand(OnMenuViewsDataGrid));

        private void OnMenuViewsDataGrid()
            => _navigationService.NavigateTo(typeof(DataGridViewModel).FullName, null, true);

        private void OnMenuFileSettings()
            => _rightPaneService.OpenInRightPane(typeof(SettingsViewModel).FullName);
    }
}
