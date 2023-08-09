using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BusinessLogicLayer.Services.Abstract;
public interface IAccountService
{
    #region Auth Requests
    Task<bool>Register(RegisterDto registerDto);
    Task<bool> Login(LoginDto loginDto);
    Task SignOutAsync();
    #endregion

    #region Get Requests

    Task<IDataResult<List<UserGetDto>>> GetAllUser(params string[] includes);
    Task<IDataResult<List<UserGetDto>>> GetAllUserByRole(string role, params string[] includes);
    Task<IDataResult<UserGetDto>> GetUserById(string id, params string[] includes);
    Task<IDataResult<UserGetDto>> GetUserByClaims(ClaimsPrincipal userClaims, params string[] includes);
    #endregion


    Task<IResult> EvokeUserToAdmin(UserGetDto dto);
    Task<IResult> RevokeFromAdmin(UserGetDto dto);
}
