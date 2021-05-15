using System.Threading.Tasks;

namespace Iqui_WareHouse.Contracts.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle();

        Task HandleAsync();
    }
}
