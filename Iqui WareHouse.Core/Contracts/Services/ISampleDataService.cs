using System.Collections.Generic;
using System.Threading.Tasks;

using Iqui_WareHouse.Core.Models;

namespace Iqui_WareHouse.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetGridDataAsync();
    }
}
