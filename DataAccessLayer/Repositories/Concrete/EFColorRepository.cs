namespace DataAccessLayer.Repositories.Concrete;

public class EFColorRepository : EntityRepositoryBase<Color, AppDbContext>, IColorRepository
{
    private readonly AppDbContext _context;

    public EFColorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}



