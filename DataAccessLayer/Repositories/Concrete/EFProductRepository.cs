namespace DataAccessLayer.Repositories.Concrete;

public class EFProductRepository : EntityRepositoryBase<Product, AppDbContext>, IProductRepository
{
    private readonly AppDbContext _context;

    public EFProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
