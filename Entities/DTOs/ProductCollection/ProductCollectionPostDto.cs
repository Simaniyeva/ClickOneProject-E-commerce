namespace Entities.DTOs.ProductCollection;

public class ProductCollectionPostDto : IDto
{
    public string CollectionImage{ get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
