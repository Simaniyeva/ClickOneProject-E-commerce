
namespace DataAccessLayer.Repositories;

public interface IUnitOfWork : IDisposable
{
    public ICategoryRepository CategoryRepository { get; }
    public ISubCategoryRepository SubCategoryRepository { get; }
    public ICompanyRepository CompanyRepository { get; }
    public IFavouriteRepository FavouriteRepository { get; }
    public IProductCollectionRepository ProductCollectionRepository { get; }
    public IProductImageRepository ProductImageRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IParameterRepository ParameterRepository { get; }
    public IProductParameterRepository ProductParameterRepository { get; }
    public IColorRepository ColorRepository { get; }
    public IReviewRepository ReviewRepository { get; }

    Task<int> SaveAsync();

}
