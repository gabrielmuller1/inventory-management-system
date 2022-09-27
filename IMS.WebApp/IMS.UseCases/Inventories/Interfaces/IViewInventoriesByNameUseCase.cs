using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}