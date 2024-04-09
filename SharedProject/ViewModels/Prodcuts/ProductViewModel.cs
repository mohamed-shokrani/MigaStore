using Microsoft.AspNetCore.Http;
using SharedProject.Models;
using SharedProject.ViewModels.Brand;
using SharedProject.ViewModels.Category;
using SharedProject.ViewModels.ProductLongDescription;
using SharedProject.ViewModels.ProductModel;
using SharedProject.ViewModels.Seller;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.ViewModels.Prodcuts;
public class ProductViewModel
{
    public int? Id { get; set; }
    [Required, StringLength(300),Display(Name ="Product Name")]
    public string Name { get; set; } = string.Empty;
    [Required, StringLength(300)]
    public string Model { get; set; } = string.Empty;
    [Required, StringLength(300)]

    public string Description { get; set; } = string.Empty;
    [Required (ErrorMessage = "The field Price must be Number and Positive Value"),Range(1,double.MaxValue)]

    public decimal Price {  get; set; }
    [Required, Range(1, int.MaxValue)]

    public int Quantity { get; set; }

    public string MediumDescription { get; set; } = string.Empty;
    public ProductLongDescriptionVM? LongDescription { get; set; } 

    public string CategoryName { get; set; } = string.Empty;
    public string SellerName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public int SellerId { get; set; }

    public long Views { get; set; }
    public IEnumerable<CategoryVM>? Categories { get; set; } 
    public IEnumerable<BrandVM>? Brands { get; set; } 
    public IEnumerable<SellerVM>? Sellers { get; set; }
    public IEnumerable<ProductImageVM>  ? ProductImagesVM { get; set; }
    public IEnumerable<IFormFile> ProductImages { get; set; }
    public IEnumerable<IFormFile>? ProductLongDescImages { get; set; }

}
