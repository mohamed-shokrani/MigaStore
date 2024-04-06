using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SharedProject.Models;
using SharedProject.ViewModels.ProductModel;

namespace SharedProject.Interfaces;
public interface IImageRepository :IGenericRepository<ProductImage>
{
    Task<List<ProductImageVM>> CreateProductImages(IEnumerable<IFormFile> files,string wwwrooPath);
}
