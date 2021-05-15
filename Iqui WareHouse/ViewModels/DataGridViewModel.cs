using System;
using System.Collections.ObjectModel;

using Iqui_WareHouse.Contracts.ViewModels;
using Iqui_WareHouse.Core.Contracts.Services;
using Iqui_WareHouse.Core.Models;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Iqui_WareHouse.ViewModels
{
    public class DataGridViewModel : ObservableObject, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public DataGridViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
