namespace Entities.Concrete;

public class SubCategory : ITable
{
    public SubCategory()
    {
        Products = new List<Product>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }

    //Relations
    public List<Product> Products { get; set; }
}

