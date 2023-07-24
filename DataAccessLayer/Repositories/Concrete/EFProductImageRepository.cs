namespace DataAccessLayer.Repositories.Concrete;

public class EFProductImageRepository : EntityRepositoryBase<ProductImage, AppDbContext>, IProductImageRepository
{
    private readonly AppDbContext _context;

    public EFProductImageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}

