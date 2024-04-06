using SharedProject.Models;

namespace SharedProject.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Brand> Brands { get; }
    IProductRepository ProductRepository { get; }
    IImageRepository ImageRepository { get; }
    IGenericRepository<Category> Categories { get; }

    IGenericRepository<Seller> Sellers { get; }
    IGenericRepository<ProductImage> ProdcutImages{ get; }

    IGenericRepository<ProductLongDescription> ProdcutFullDescription { get; }
    Task SaveChangesAsync();

}
