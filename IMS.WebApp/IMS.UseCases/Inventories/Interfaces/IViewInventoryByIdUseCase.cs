using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExecuteAsync(int inventoryId);
    }
}