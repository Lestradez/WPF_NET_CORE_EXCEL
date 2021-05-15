using System;

using Iqui_WareHouse.Models;

namespace Iqui_WareHouse.Contracts.Services
{
    public interface IThemeSelectorService
    {
        void InitializeTheme();

        void SetTheme(AppTheme theme);

        AppTheme GetCurrentTheme();
    }
}
