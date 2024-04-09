
using Microsoft.AspNetCore.Http;
using SharedProject.Models;
using SharedProject.ViewModels.ProductLongDescription;
namespace SharedProject.ViewModels.ProductModel;

public class ProductImageVM
{
    public int Id { get; set; }
   
    public string? ImagePath { get; set;}
    public IFormFile Cover { get; set; } = default!;
  
}
