
using IResult = BusinessLogicLayer.Utilities.Results.IResult;

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
		List<SubCategory> subCategories = getDeleted
			? await _unitOfWork.SubCategoryRepository.GetAllAsync(includes: includes)
			: await _unitOfWork.SubCategoryRepository.GetAllAsync(b => !b.isDeleted, includes);
		if (subCategories is null)
		{
			return new ErrorDataResult<List<SubCategoryGetDto>>(Messages.NotFound(Messages.SubCategory));
		}
		return new SuccessDataResult<List<SubCategoryGetDto>>(_mapper.Map<List<SubCategoryGetDto>>(subCategories));
	}

	public async Task<IDataResult<SubCategoryGetDto>> GetByIdAsync(int id, params string[] includes)
	{
		SubCategory subCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id, includes);
		if (subCategory is null)
		{
			return new ErrorDataResult<SubCategoryGetDto>(Messages.NotFound(Messages.SubCategory));
		}
		return new SuccessDataResult<SubCategoryGetDto>(_mapper.Map<SubCategoryGetDto>(subCategory));
	}
	#endregion

	#region Post Requests
	public async Task<IResult> CreateAsync(SubCategoryPostDto dto)
	{
		SubCategory subCategory = _mapper.Map<SubCategory>(dto);
		await _unitOfWork.SubCategoryRepository.CreateAsync(subCategory);
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
		SubCategory subCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == dto.Id && !b.isDeleted);
		subCategory = _mapper.Map<SubCategory>(dto);
		_unitOfWork.SubCategoryRepository.Update(subCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotUpdated(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Updated(Messages.SubCategory));
	}
	public async Task<IResult> RecoverByIdAsync(int id)
	{
		SubCategory subCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id && b.isDeleted);
		subCategory.isDeleted = false;
		_unitOfWork.SubCategoryRepository.Update(subCategory);
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
		SubCategory subCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id && b.isDeleted);
		_unitOfWork.SubCategoryRepository.Delete(subCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Deleted(Messages.SubCategory));
	}
	public async Task<IResult> SoftDeleteByIdAsync(int id)
	{
		SubCategory subCategory = await _unitOfWork.SubCategoryRepository.GetAsync(b => b.Id == id && !b.isDeleted);
		subCategory.isDeleted = true;
		_unitOfWork.SubCategoryRepository.Update(subCategory);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.SubCategory));
		}
		return new SuccessResult(Messages.Deleted(Messages.SubCategory));
	}
	#endregion
}