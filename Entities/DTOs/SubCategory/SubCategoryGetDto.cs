using Entities.DTOs.Category;

namespace Entities.DTOs.SubCategory;

public class SubCategoryGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }

    //Relations
    public int CategoryId { get; set; }
    public CategoryGetDto Category { get; set; }
    public List<ProductGetDto> Products { get; set; }
}
