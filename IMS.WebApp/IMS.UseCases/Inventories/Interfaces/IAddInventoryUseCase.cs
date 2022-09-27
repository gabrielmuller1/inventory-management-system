using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}