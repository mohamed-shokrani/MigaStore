
namespace SharedProject.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int  Quantity { get; set; }

    public string MediumDescription { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;  
    public int CategoryId { get; set; }
    public long Views { get; set; }


    public Category Category { get; set; }    
    public int BrandId { get; set; }

    public Brand Brand { get; set; } 
    public int ModelId { get; set; }

    public Model Model { get; set; }
    public int SellerId { get; set; }

    public ICollection<Seller> Sellers { get; set; } 


}
