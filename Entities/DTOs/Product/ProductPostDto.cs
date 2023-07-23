namespace Entities.DTOs.Product;

public class ProductPostDto : IDto
{
    public ProductPostDto()
    {
        ParameterIds = new List<int>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    //Relations
    public int SubCategoryId { get; set; }
    public int? ProductCollectionId { get; set; }
    public int? ColorId { get; set; }
    public List<IFormFile> formFiles { get; set; }
    public List<int>? ParameterIds { get; set; }
}
