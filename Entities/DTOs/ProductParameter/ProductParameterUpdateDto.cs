namespace Entities.DTOs.ProductParameter;

public class ProductParameterUpdateDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ParameterId { get; set; }
}