using Microsoft.AspNetCore.Mvc;
using SharedProject.ViewModels.Prodcuts;
using SharedProject.Interfaces;
using SharedProject.Models;
using SharedProject.ViewModels.Brand;
using SharedProject.ViewModels.Category;
using SharedProject.ViewModels.Seller;
namespace AdminDashboardProject.Controllers;
[Route("products/")]
public class ProductsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ProductsController(IUnitOfWork context, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = context;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task< IActionResult> Index()
    {
        var all =await _unitOfWork.ProductRepository.GetAllProducts();
        return View(all);
    }
    [Route("new")]

    public async Task<IActionResult> New()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        var brands = await _unitOfWork.Brands.GetAllAsync();
        var seller = await _unitOfWork.Sellers.GetAllAsync();

        ProductViewModel productVM = ProductMap(categories, brands, seller);

        return View(productVM);
    }
    [HttpPost("new")]
    public async Task<IActionResult> New(ProductViewModel productView   )
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        var brands = await _unitOfWork.Brands.GetAllAsync();
       
        var seller = await _unitOfWork.Sellers.GetAllAsync();
      
        ProductViewModel productVM = ProductMap(categories, brands, seller);
        if (ModelState.IsValid)
        {
            string wwwrootPath = _webHostEnvironment.WebRootPath;
            var images = await _unitOfWork.ImageRepository.CreateProductImages(productView.ProductImages, wwwrootPath);
             var product = new Product
            {
                Name = productView.Name,
                Model = productView.Model,
                MediumDescription = productView.MediumDescription,
                Description = productView.Description,
                Price = productView.Price,
                Quantity = productView.Quantity,
                BrandId = productView.BrandId,
                SellerId = productView.SellerId,
                CategoryId = productView.CategoryId,
                ProductImages = images.Select(x => new ProductImage
                                    {
                                        ImagePath = x.ImagePath,
                                        IsMain = true
                                    }).ToList()
            };
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(productVM);
    }

    [Route("categories")]

    public async Task<IActionResult> GetAllCategories()
    {
        var cat =await _unitOfWork.Categories.GetAllAsync();
        return View(cat);
    }
    private static ProductViewModel ProductMap(IReadOnlyCollection<Category> categories, IReadOnlyCollection<Brand> brands, IReadOnlyCollection<Seller> seller)
    {
        return new ProductViewModel
        {
            Brands = brands.Select(x => new BrandVM
            {
                Name = x.Name,
                Id = x.Id,
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

}