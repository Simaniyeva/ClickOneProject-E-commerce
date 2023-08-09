
using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace BusinessLogicLayer.Services.Concrete;

public class ParameterManager : IParameterService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public ParameterManager(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	#region Get Requests
	public async Task<IDataResult<List<ParameterGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
	{
		List<Parameter> parameters = getDeleted
			? await _unitOfWork.ParameterRepository.GetAllAsync(includes: includes)
			: await _unitOfWork.ParameterRepository.GetAllAsync(b => !b.isDeleted, includes);
		if (parameters is null)
		{
			return new ErrorDataResult<List<ParameterGetDto>>(Messages.NotFound(Messages.Parameter));
		}
		return new SuccessDataResult<List<ParameterGetDto>>(_mapper.Map<List<ParameterGetDto>>(parameters));
	}

	public async Task<IDataResult<ParameterGetDto>> GetByIdAsync(int id, params string[] includes)
	{
		Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(b => b.Id == id, includes);
		if (parameter is null)
		{
			return new ErrorDataResult<ParameterGetDto>(Messages.NotFound(Messages.Parameter));
		}
		return new SuccessDataResult<ParameterGetDto>(_mapper.Map<ParameterGetDto>(parameter));
	}
	#endregion

	#region Post Requests
	public async Task<IResult> CreateAsync(ParameterPostDto dto)
	{
		Parameter parameter = _mapper.Map<Parameter>(dto);
		await _unitOfWork.ParameterRepository.CreateAsync(parameter);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotCreated(Messages.Parameter));
		}
		return new SuccessResult(Messages.Created(Messages.Parameter));
	}

	#endregion

	#region Update Requests
	public async Task<IResult> UpdateAsync(ParameterUpdateDto dto)
	{
		Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(b => b.Id == dto.Id && !b.isDeleted);
		parameter = _mapper.Map<Parameter>(dto);
		_unitOfWork.ParameterRepository.Update(parameter);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotUpdated(Messages.Parameter));
		}
		return new SuccessResult(Messages.Updated(Messages.Parameter));
	}
	public async Task<IResult> RecoverByIdAsync(int id)
	{
		Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(b => b.Id == id && b.isDeleted);
		parameter.isDeleted = false;
		_unitOfWork.ParameterRepository.Update(parameter);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotRecovered(Messages.Parameter));
		}
		return new SuccessResult(Messages.Recovered(Messages.Parameter));
	}
	#endregion

	#region Delete Requests
	public async Task<IResult> HardDeleteByIdAsync(int id)
	{
		Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(b => b.Id == id && b.isDeleted);
		_unitOfWork.ParameterRepository.Delete(parameter);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.Parameter));
		}
		return new SuccessResult(Messages.Deleted(Messages.Parameter));
	}
	public async Task<IResult> SoftDeleteByIdAsync(int id)
	{
		Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(b => b.Id == id && !b.isDeleted);
		parameter.isDeleted = true;
		_unitOfWork.ParameterRepository.Update(parameter);
		int result = await _unitOfWork.SaveAsync();
		if (result is 0)
		{
			return new ErrorResult(Messages.NotDeleted(Messages.Parameter));
		}
		return new SuccessResult(Messages.Deleted(Messages.Parameter));
	}
	#endregion
}