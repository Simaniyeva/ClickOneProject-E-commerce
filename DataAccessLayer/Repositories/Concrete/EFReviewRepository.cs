namespace DataAccessLayer.Repositories.Concrete;

public class EFReviewRepository : EntityRepositoryBase<Review, AppDbContext>, IReviewRepository
{
    private readonly AppDbContext _context;

    public EFReviewRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
