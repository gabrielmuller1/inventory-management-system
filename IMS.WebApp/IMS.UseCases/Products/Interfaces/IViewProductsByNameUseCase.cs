using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}