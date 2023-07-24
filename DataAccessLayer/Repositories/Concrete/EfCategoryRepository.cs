namespace DataAccessLayer.Repositories.Concrete;

public class EFCategoryRepository : EntityRepositoryBase<Category,AppDbContext> , ICategoryRepository
{
    private readonly AppDbContext _context;

    public EFCategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}