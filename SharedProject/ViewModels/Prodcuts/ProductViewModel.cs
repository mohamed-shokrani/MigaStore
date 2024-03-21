using SharedProject.Models;
using SharedProject.ViewModels.Brand;
using SharedProject.ViewModels.Category;
using SharedProject.ViewModels.Seller;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.ViewModels.Prodcuts;
public class ProductViewModel
{
    public int Id { get; set; }
    [Required, StringLength(300)]
    public string Name { get; set; } = string.Empty;
    [Required, StringLength(300)]

    public string Description { get; set; } = string.Empty;
    [Required]

    public decimal Price { get; set; }
    [Required]

    public int Quantity { get; set; }
    [Required]

    public string MediumDescription { get; set; } = string.Empty;
    [Required]

    public string MainImage { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string SellerName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public int SellerId { get; set; }

    public long Views { get; set; }
    public IEnumerable<CategoryVM> Categories { get; set; }
    public IEnumerable<BrandVM> Brands { get; set; }
    public IEnumerable<SellerVM> Sellers { get; set; }

}
