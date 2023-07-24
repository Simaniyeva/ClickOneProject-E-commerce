namespace DataAccessLayer.Repositories.Concrete;

public class EFParameterRepository : EntityRepositoryBase<Parameter, AppDbContext>, IParameterRepository
{
    private readonly AppDbContext _context;

    public EFParameterRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
