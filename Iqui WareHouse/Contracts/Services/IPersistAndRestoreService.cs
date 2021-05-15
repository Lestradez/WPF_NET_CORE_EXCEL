namespace Iqui_WareHouse.Contracts.Services
{
    public interface IPersistAndRestoreService
    {
        void RestoreData();

        void PersistData();
    }
}
