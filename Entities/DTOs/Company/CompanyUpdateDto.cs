
namespace Entities.DTOs.Company;

public class CompanyUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile formFile { get; set; }
    public string InstagramUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string LinkedinUrl { get; set; }

}
