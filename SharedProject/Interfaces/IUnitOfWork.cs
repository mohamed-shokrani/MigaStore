using SharedProject.Models;

namespace SharedProject.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Brand> Brands { get; }
    IProductRepository ProductRepository { get; }
    IGenericRepository<Category> Categories { get; }

    IGenericRepository<Model> Models { get; }
    IGenericRepository<Seller> Sellers { get; }

}
