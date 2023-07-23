namespace Entities.DTOs.Product;

public class ProductUpdateDto : IDto
{
    public ProductUpdateDto()
    {
        ParameterIds = new List<int>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int DiscountPercent { get; set; }
    public decimal TotalRating { get; set; }
    //Relations
    public int SubCategoryId { get; set; }
    public int? ProductCollectionId { get; set; }
    public int? ColorId { get; set; }
    public List<IFormFile> formFiles { get; set; }
    public List<int>? ParameterIds { get; set; }
}