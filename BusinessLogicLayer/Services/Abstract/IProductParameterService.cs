
namespace BusinessLogicLayer.Services.Abstract;

public interface IProductParameterService
{
	Task<IDataResult<List<ProductParameterGetDto>>> GetAllAsync(params string[] includes);
	Task<IDataResult<ProductParameterGetDto>> GetByIdAsync(int id, params string[] includes);
	Task<IResult> CreateAsync(ProductParameterPostDto dto);
	Task<IResult> UpdateAsync(ProductParameterUpdateDto dto);
	Task<IResult> HardDeleteByIdAsync(int id);
}