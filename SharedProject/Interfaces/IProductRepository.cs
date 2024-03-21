using SharedProject.Helper;
using SharedProject.Models;
using SharedProject.ViewModels.Prodcuts;

namespace SharedProject.Interfaces;
public interface IProductRepository :IGenericRepository<Product>
{
    Task<IReadOnlyCollection<ProductViewModel>> GetAllProducts(ProductSpecParams specParams = null);

}
