namespace DataAccessLayer.Repositories.Concrete;

public class EFProductParameterRepository : EntityRepositoryBase<ProductParameter, AppDbContext>, IProductParameterRepository
{
    private readonly AppDbContext _context;

    public EFProductParameterRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}




