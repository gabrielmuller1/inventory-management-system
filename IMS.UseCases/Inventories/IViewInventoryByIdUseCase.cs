using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExecuteAsync ( int inventoryId );
    }
}