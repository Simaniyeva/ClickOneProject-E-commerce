namespace Entities.DTOs.ProductParameter;

public class ProductParameterPostDto : IDto
{
    public int ProductId { get; set; }
    public int ParameterId { get; set; }
}
