using Microsoft.EntityFrameworkCore;
using SharedProject.Data;
using SharedProject.Helper;
using SharedProject.Interfaces;
using SharedProject.Models;
using SharedProject.ViewModels.Prodcuts;

namespace SharedProject.DataAccess;
public class ProductRepository : GenericRepository<Product> ,IProductRepository
{
    protected AppDbContext _context;
    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection< ProductViewModel>> GetAllProducts(ProductSpecParams specParams )
    {
       var result = await _context.Products.Include(x=>x.Category)
                                            .AsNoTracking()
                                            .Select(x=> new ProductViewModel
                                                    {
                                                                    
                                                    Id = x.Id,
                                                    Name = x.Name,
                                                    Description = x.Description,
                                                    Price = x.Price,
                                                    Quantity = x.Quantity,
                                                    Views = x.Views,
                                                    MediumDescription = x.MediumDescription,
                                                    CategoryName = x.Category.Name
                                                                   
                                                                    

                                                    }).ToListAsync();
        return result;

    }
}
