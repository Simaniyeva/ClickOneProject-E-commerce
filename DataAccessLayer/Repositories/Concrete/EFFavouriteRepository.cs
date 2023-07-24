namespace DataAccessLayer.Repositories.Concrete;

public class EFFavouriteRepository : EntityRepositoryBase<Favourite, AppDbContext>, IFavouriteRepository
{
    private readonly AppDbContext _context;

    public EFFavouriteRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}










