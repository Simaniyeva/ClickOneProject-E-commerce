using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BusinessLogicLayer.Services.Concrete;
public class ProductParameterManager : IProductParameterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductParameterManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Get Requests
    public async Task<IDataResult<List<ProductParameterGetDto>>> GetAllAsync(params string[] includes)
    {
        List<ProductParameter> productParameters = await _unitOfWork.ProductParameterRepository.GetAllAsync(includes: includes);
        if (productParameters is null) return new ErrorDataResult<List<ProductParameterGetDto>>(Messages.NotFound(Messages.ProductParameter));
        return new SuccessDataResult<List<ProductParameterGetDto>>(_mapper.Map<List<ProductParameterGetDto>>(productParameters));
    }

    public async Task<IDataResult<ProductParameterGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        ProductParameter productParameter = await _unitOfWork.ProductParameterRepository.GetAsync(b => b.Id == id, includes);
        if (productParameter is null) return new ErrorDataResult<ProductParameterGetDto>(Messages.NotFound(Messages.ProductParameter));
        return new SuccessDataResult<ProductParameterGetDto>(_mapper.Map<ProductParameterGetDto>(productParameter));
    }

    #endregion


    #region Post Requests
    public async Task<Utilities.Results.IResult> CreateAsync(ProductParameterPostDto dto)
    {
        ProductParameter productParameter = _mapper.Map<ProductParameter>(dto);
        await _unitOfWork.ProductParameterRepository.CreateAsync(productParameter);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0) return new ErrorResult(Messages.NotCreated(Messages.ProductParameter));
        return new SuccessResult(Messages.Created(Messages.ProductParameter));
    }
    #endregion

    #region Update Requests
    public async Task<Utilities.Results.IResult> UpdateAsync(ProductParameterUpdateDto dto)
    {
        ProductParameter ProductParameter = await _unitOfWork.ProductParameterRepository.GetAsync(b => b.Id == dto.Id);
        ProductParameter = _mapper.Map<ProductParameter>(ProductParameter);
        _unitOfWork.ProductParameterRepository.Update(ProductParameter);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0) return new ErrorResult(Messages.NotUpdated(Messages.ProductParameter));
        return new SuccessResult(Messages.Updated(Messages.ProductParameter));
    }


    #endregion

    #region Delete Requests
    public async Task<Utilities.Results.IResult> HardDeleteByIdAsync(int id)
    {
        ProductParameter ProductParameter =await _unitOfWork.ProductParameterRepository.GetAsync(b=>b.Id==id);
        _unitOfWork.ProductParameterRepository.Delete(ProductParameter);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)  return new ErrorResult(Messages.NotDeleted(Messages.ProductParameter));
        return new SuccessResult(Messages.Deleted(Messages.ProductParameter));
    }
    #endregion

}