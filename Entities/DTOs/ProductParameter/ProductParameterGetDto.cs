
namespace Entities.DTOs.ProductParameter;

public class ProductParameterGetDto:IDto
{
    public int Id { get; set; }
    public ProductGetDto Product { get; set; }
    public ParameterGetDto Parameter { get; set; }
}
