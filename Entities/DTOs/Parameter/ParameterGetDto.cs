
namespace Entities.DTOs.Parameter;

public class ParameterGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
    //Relations
    public List<ProductParameterGetDto> ProductParameters { get; set; }
}
