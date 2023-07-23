namespace Entities.DTOs.SubCategory;

public class SubCategoryPostDto : IDto
{
    public string Name { get; set; }
    //Relations
    public int CategoryId { get; set; }
}
