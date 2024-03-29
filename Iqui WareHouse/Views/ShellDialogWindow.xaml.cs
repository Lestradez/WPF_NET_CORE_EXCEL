﻿using System.Windows.Controls;

using Iqui_WareHouse.Contracts.Views;
using Iqui_WareHouse.ViewModels;

using MahApps.Metro.Controls;

namespace Iqui_WareHouse.Views
{
    public partial class ShellDialogWindow : MetroWindow, IShellDialogWindow
    {
        public ShellDialogWindow(ShellDialogViewModel viewModel)
        {
            InitializeComponent();
            viewModel.SetResult = OnSetResult;
            DataContext = viewModel;
        }

        public Frame GetDialogFrame()
            => dialogFrame;

        private void OnSetResult(bool? result)
        {
            DialogResult = result;
            Close();
        }
    }
}
