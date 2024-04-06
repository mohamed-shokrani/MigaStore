
using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models;
public class Product
{
    public int Id { get; set; }
    [Required,StringLength(300)]
    public string Name { get; set; } = string.Empty;
    [Required, StringLength(300)]

    public string Description { get; set; } = string.Empty;
    [Required]

    public decimal Price { get; set; }
    [Required]

    public int  Quantity { get; set; }
    [Required]
    public string Model { get; set; } = string.Empty;
  
    public string MediumDescription { get; set; } = string.Empty;
    [Required]

    public int CategoryId { get; set; }
    public long Views { get; set; }


    public Category Category { get; set; }    
    public int BrandId { get; set; }

    public Brand Brand { get; set; } 
   

    public int SellerId { get; set; }

    public ICollection<Seller> Sellers { get; set; }
    public ICollection<ProductImage> ProductImages  { get; set; }


}
