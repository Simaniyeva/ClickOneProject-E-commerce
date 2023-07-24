namespace DataAccessLayer.Repositories.Concrete;

public class EFSubCategoryRepository : EntityRepositoryBase<SubCategory, AppDbContext>, ISubCategoryRepository
{
    private readonly AppDbContext _context;

    public EFSubCategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
