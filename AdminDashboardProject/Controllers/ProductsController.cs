using SharedProject.Data;
using Microsoft.AspNetCore.Mvc;
using SharedProject.ViewModels.Prodcuts;
using SharedProject.Interfaces;
using SharedProject.Models;
using SharedProject.ViewModels.Brand;
using SharedProject.ViewModels.Category;
using SharedProject.ViewModels.Seller;
namespace AdminDashboardProject.Controllers;
public class ProductsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork context)
    {
        _unitOfWork = context;
    }
    [Route("products")]
    public async Task< IActionResult> Index()
    {
        var all =await _unitOfWork.ProductRepository.GetAllProducts();
        return View(all);
    }
    public async Task<IActionResult> New()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        var brands = await _unitOfWork.Brands.GetAllAsync();
        var seller = await _unitOfWork.Sellers.GetAllAsync();

        ProductViewModel productVM = ProductMap(categories, brands, seller);

        return View(productVM);
    }

    private static ProductViewModel ProductMap(IReadOnlyCollection<Category> categories, IReadOnlyCollection<Brand> brands, IReadOnlyCollection<Seller> seller)
    {
        return new ProductViewModel
        {
            Brands = brands.Select(x => new BrandVM
            {
                Name = x.Name,
            }),
            Categories = categories.Select(x => new CategoryVM
            {
                Name = x.Name,
                Id = x.Id,
            }),
            Sellers = seller.Select(x => new SellerVM
            {
                Name = x.Name,
                Id = x.Id,
            }),
        };
    }

    [Route("categories")]

    public async Task<IActionResult> GetAllCategories()
    {
        var cat =await _unitOfWork.Categories.GetAllAsync();
        return View(cat);
    } 

    
}