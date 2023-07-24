using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;

namespace DataAccessLayer.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ICategoryRepository _categoryRepository;
    private ISubCategoryRepository _subCategoryRepository;
    private IFavouriteRepository _favouriteRepository;
    private IProductCollectionRepository _productCollectionRepository;
    private IProductImageRepository _productImageRepository;
    private IProductRepository _productRepository;
    private IParameterRepository _parameterRepository;
    private IProductParameterRepository _productParameterRepository;
    private IColorRepository _colorRepository;
    private IReviewRepository _reviewRepository;
    private ICompanyRepository _companyRepository;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ICategoryRepository CategoryRepository => _categoryRepository = _categoryRepository ?? new EFCategoryRepository(_context);
    public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository = _subCategoryRepository ?? new EFSubCategoryRepository(_context);
    public IFavouriteRepository FavouriteRepository => _favouriteRepository = _favouriteRepository ?? new EFFavouriteRepository(_context);
    public IProductCollectionRepository ProductCollectionRepository => _productCollectionRepository = _productCollectionRepository ?? new EFProductCollectionRepository(_context);
    public IProductImageRepository ProductImageRepository => _productImageRepository = _productImageRepository ?? new EFProductImageRepository(_context);
    public IProductRepository ProductRepository => _productRepository = _productRepository ?? new EFProductRepository(_context);
    public IProductParameterRepository ProductParameterRepository => _productParameterRepository = _productParameterRepository ?? new EFProductParameterRepository(_context);
    public IParameterRepository ParameterRepository => _parameterRepository = _parameterRepository ?? new EFParameterRepository(_context);
    public IColorRepository ColorRepository => _colorRepository = _colorRepository ?? new EFColorRepository(_context);
    public IReviewRepository ReviewRepository => _reviewRepository = _reviewRepository ?? new EFReviewRepository(_context);
    public ICompanyRepository CompanyRepository => _companyRepository = _companyRepository ?? new EFCompanyRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
