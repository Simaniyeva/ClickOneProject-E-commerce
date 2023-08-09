using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BusinessLogicLayer.Services.Concrete;

public class CompanyManager : ICompanyService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CompanyManager(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	#region Get Requests
	public async Task<IDataResult<List<CompanyGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
	{
		List<Company> companies = getDeleted
			? await _unitOfWork.CompanyRepository.GetAllAsync(includes: includes)
			: await _unitOfWork.CompanyRepository.GetAllAsync(b => !b.isDeleted, includes);
		if (companies is null)
		{
			return new ErrorDataResult<List<CompanyGetDto>>(Messages.NotFound(Messages.Company));
		}
		return new SuccessDataResult<List<CompanyGetDto>>(_mapper.Map<List<CompanyGetDto>>(companies));
	}

	public async Task<IDataResult<CompanyGetDto>> GetByIdAsync(int id, params string[] includes)
	{
		Company company = await _unitOfWork.CompanyRepository.GetAsync(b => b.Id == id, includes);
		if (company is null)
		{
			return new ErrorDataResult<CompanyGetDto>(Messages.NotFound(Messages.Company));
		}
		return new SuccessDataResult<CompanyGetDto>(_mapper.Map<CompanyGetDto>(company));
	}
	#endregion

	#region Post Requests
	public async Task<IResult> CreateAsync(CompanyPostDto dto)
	{
		Company company = _mapper.Map<Company>(dto);
		await _unitOfWork.CompanyRepository.CreateAsync(company);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotCreated(Messages.Company));
		}
		return new SuccessResult(Messages.Created(Messages.Company));
	}

	#endregion

	#region Update Requests
	public async Task<IResult> UpdateAsync(CompanyUpdateDto dto)
	{
		Company company = await _unitOfWork.CompanyRepository.GetAsync(b => b.Id == dto.Id && !b.isDeleted);
		company = _mapper.Map<Company>(dto);
		_unitOfWork.CompanyRepository.Update(company);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotUpdated(Messages.Company));
		}
		return new SuccessResult(Messages.Updated(Messages.Company));
	}
	public async Task<IResult> RecoverByIdAsync(int id)
	{
		Company company = await _unitOfWork.CompanyRepository.GetAsync(b => b.Id == id && b.isDeleted);
		company.isDeleted = false;
		_unitOfWork.CompanyRepository.Update(company);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotRecovered(Messages.Company));
		}
		return new SuccessResult(Messages.Recovered(Messages.Company));
	}
	#endregion

	#region Delete Requests
	public async Task<IResult> HardDeleteByIdAsync(int id)
	{
		Company company = await _unitOfWork.CompanyRepository.GetAsync(b => b.Id == id && b.isDeleted);
		_unitOfWork.CompanyRepository.Delete(company);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.Company));
		}
		return new SuccessResult(Messages.Deleted(Messages.Company));
	}
	public async Task<IResult> SoftDeleteByIdAsync(int id)
	{
		Company company = await _unitOfWork.CompanyRepository.GetAsync(b => b.Id == id && !b.isDeleted);
		company.isDeleted = true;
		_unitOfWork.CompanyRepository.Update(company);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.Company));
		}
		return new SuccessResult(Messages.Deleted(Messages.Company));
	}
	#endregion
}