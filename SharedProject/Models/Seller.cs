namespace SharedProject.Models;

public class Seller
{
    public int Id { get; set; }
    public string SellerCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; }  

}
