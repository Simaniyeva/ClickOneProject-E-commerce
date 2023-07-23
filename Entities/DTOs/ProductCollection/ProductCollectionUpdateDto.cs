namespace Entities.DTOs.ProductCollection;

public class ProductCollectionUpdateDto : IDto
{
    public int Id { get; set; }
    public string CollectionImage { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}