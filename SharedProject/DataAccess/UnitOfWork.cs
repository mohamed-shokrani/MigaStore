using SharedProject.Data;
using SharedProject.Interfaces;
using SharedProject.Models;

namespace SharedProject.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepository {  get;private set; }
    public IGenericRepository<Brand> Brands { get; private set; }
    public IGenericRepository<Category> Categories { get; private set; }

    public IGenericRepository<Model> Models { get; private set; }
    public IGenericRepository<Seller> Sellers { get; private set; }


    private readonly AppDbContext _context;
    public UnitOfWork( AppDbContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(_context);
        Brands = new GenericRepository<Brand>( _context);
        Categories = new GenericRepository<Category>( _context);
        Models = new GenericRepository<Model>(_context);
        Sellers = new GenericRepository<Seller>( _context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
