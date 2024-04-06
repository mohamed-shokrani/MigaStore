
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SharedProject.Data;
using SharedProject.Interfaces;
using SharedProject.Models;
using SharedProject.Settings;
using SharedProject.ViewModels.ProductModel;



namespace SharedProject.DataAccess;

public class ImageRepository : GenericRepository<ProductImage> ,IImageRepository
{
    private readonly AppDbContext _context;
   

    public ImageRepository(AppDbContext context ) : base(context)
    {
        _context = context;
     
    }
   
    public async Task<List<ProductImageVM>> CreateProductImages(IEnumerable<IFormFile> files,string wwwrootPath)
    {
        if (!files.Any() )
        {
            return [];
        }
        string _serverPath = $"{wwwrootPath}{FileSetting.ImagePath}";
        var ImagesCollection = new List<ProductImageVM>();
      

        var tasks = new List<Task>();
        foreach (var file in files)
        {
            var imagePath = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var serverPath = Path.Combine(_serverPath, imagePath);
            ImagesCollection.Add(new ProductImageVM
            {
                ImagePath = imagePath,

            });
            tasks.Add(Task.Run(async () =>
            {
                using var stram = File.Create(serverPath);
                await file.CopyToAsync(stram);

            }));
        }
        await Task.WhenAll(tasks);

        return ImagesCollection;

    }
}

    
