namespace SharedProject.Models;

public class ProductLongDescription
{
    public int Id { get; set; }
    public string FullDescription { get; set; } = string.Empty;
    public ICollection<ProductLongDescImage>? Images { get; set; }
    public int ProductId { get; set; }
    public Product Product{ get; set; } 
}
