namespace DataAccessLayer.Repositories.Concrete;

public class EFCompanyRepository : EntityRepositoryBase<Company, AppDbContext>, ICompanyRepository
{
    private readonly AppDbContext _context;

    public EFCompanyRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}



