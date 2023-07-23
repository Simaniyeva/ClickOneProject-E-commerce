namespace Entities.DTOs.Product;

public class ProductGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal LastPrice { get; set; }
    public int DiscountPercent { get; set; }
    public decimal Price { get; set; }
    public decimal TotalRating { get; set; }
    public bool isSale { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    //Relations
    public SubCategoryGetDto SubCategory { get; set; }
    public ProductCollectionGetDto? ProductCollection { get; set; }
    public ColorGetDto? Color { get; set; }
    public List<ProductImage> ProductImages { get; set; }
    public List<ReviewGetDto> Reviews { get; set; }
    public List<ProductParameterGetDto> ProductParameters { get; set; }
    public List<FavouriteGetDto> Favourities { get; set; }
}
