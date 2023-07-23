
namespace Entities.DTOs.Company;

public class CompanyPostDto : IDto
{
    public CompanyPostDto()
    {
        Products = new List<ProductGetDto>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile formFile { get; set; }
    public string InstagramUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string LinkedinUrl { get; set; }
    public List<ProductGetDto> Products { get; set; }

}
