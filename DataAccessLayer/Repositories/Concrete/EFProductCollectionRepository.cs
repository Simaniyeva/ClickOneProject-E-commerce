namespace DataAccessLayer.Repositories.Concrete;

public class EFProductCollectionRepository : EntityRepositoryBase<ProductCollection, AppDbContext>, IProductCollectionRepository
{
    private readonly AppDbContext _context;

    public EFProductCollectionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
