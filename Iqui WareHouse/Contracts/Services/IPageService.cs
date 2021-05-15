using System;
using System.Windows.Controls;

namespace Iqui_WareHouse.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
