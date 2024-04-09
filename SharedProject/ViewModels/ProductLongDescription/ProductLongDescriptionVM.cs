using SharedProject.Models;
using SharedProject.ViewModels.ProductModel;

namespace SharedProject.ViewModels.ProductLongDescription;

public class ProductLongDescriptionVM
{
    public int Id { get; set; }
    public string? FullDescription { get; set; }
    public ICollection<ProductImageVM>? ProductLongDescriptionImages { get; set; }
    //public static implicit operator SharedProject.Models.ProductLongDescription(ProductLongDescriptionVM vm)
    //{
    //    // Map the properties from the view model to the entity
    //    return new SharedProject.Models.ProductLongDescription { Id = vm.Id, FullDescription = vm.FullDescription ,
    //                                        Images = vm.ProductLongDescriptionImages.Select(x=> new ProductImage
    //                                        {
    //                                            ImagePath = x.ImagePath,
                                                

    //                                        }).ToList()};
    //}
}
