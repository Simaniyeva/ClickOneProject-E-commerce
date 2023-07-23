namespace Entities.Concrete;
public class Company : ITable
{
    public Company()
    {
        Products = new List<Product>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public string InstagramUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string LinkedinUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool isDeleted { get; set; }
    //Relations
    public List<Product> Products { get; set; }

}
