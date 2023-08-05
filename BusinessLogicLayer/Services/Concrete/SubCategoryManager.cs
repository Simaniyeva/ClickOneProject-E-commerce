

namespace BusinessLogicLayer.Services.Concrete;

public class SubCategoryManager : ISubCategoryService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public SubCategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	#region Get Requests
	public async Task<IDataResult<List<SubCategoryGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
	{
		List<SubCategory> categories = getDeleted
			? await _unitOfWork.SubCategoryRepository.GetAllAsync(includes: includes)
			: await _unitOfWork.SubCategoryRepository.GetAllAsync(b => !b.isDeleted, includes);
		if (categories is null)
		{
			return new ErrorDataResult<List<SubCategoryGetDto>>(Messages.NotFound(Messages.SubCategory));
		}
		return new SuccessDataResult<List<SubCategoryGetDto>>(_mapper.Map<List<SubCategoryGetDto>>(categories));
	}

	public async Task<IDataResult<SubCategoryGetDto>> GetByIdAsync(int id, params string[] includes)
	{
		SubCategory SubCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id, includes);
		if (SubCategory is null)
		{
			return new ErrorDataResult<SubCategoryGetDto>(Messages.NotFound(Messages.SubCategory));
		}
		return new SuccessDataResult<SubCategoryGetDto>(_mapper.Map<SubCategoryGetDto>(SubCategory));
	}
	#endregion

	#region Post Requests
	public async Task<IResult> CreateAsync(SubCategoryPostDto dto)
	{
		SubCategory SubCategory = _mapper.Map<SubCategory>(dto);
		await _unitOfWork.SubCategoryRepository.CreateAsync(SubCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotCreated(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Created(Messages.SubCategory));
	}

	#endregion

	#region Update Requests
	public async Task<IResult> UpdateAsync(SubCategoryUpdateDto dto)
	{
		SubCategory SubCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == dto.Id && !b.isDeleted);
		SubCategory = _mapper.Map<SubCategory>(dto);
		_unitOfWork.SubCategoryRepository.Update(SubCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotUpdated(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Updated(Messages.SubCategory));
	}
	public async Task<IResult> RecoverByIdAsync(int id)
	{
		SubCategory SubCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id && b.isDeleted);
		SubCategory.isDeleted = false;
		_unitOfWork.SubCategoryRepository.Update(SubCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotRecovered(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Recovered(Messages.SubCategory));
	}
	#endregion

	#region Delete Requests
	public async Task<IResult> HardDeleteByIdAsync(int id)
	{
		SubCategory SubCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id && b.isDeleted);
		_unitOfWork.SubCategoryRepository.Delete(SubCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Deleted(Messages.SubCategory));
	}
	public async Task<IResult> SoftDeleteByIdAsync(int id)
	{
		SubCategory SubCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id && !b.isDeleted);
		SubCategory.isDeleted = true;
		_unitOfWork.SubCategoryRepository.Update(SubCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Deleted(Messages.SubCategory));
	}
	#endregion
}