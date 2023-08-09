using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BusinessLogicLayer.Services.Concrete;

public class AccountManager : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IActionContextAccessor _ActionContextAccessor;


    public AccountManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IActionContextAccessor actionContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _ActionContextAccessor = actionContextAccessor;
    }


    #region Auth Requests
    public async Task<bool> Login(LoginDto loginDto)
    {
        AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user is null)
        {
            _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "User is not exist!");
            return false;
        }

        if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
        {
            _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Email or Password is incorrect!");
            return false;
        }
        Microsoft.AspNetCore.Identity.SignInResult result =  await _signInManager.PasswordSignInAsync(user,loginDto.Password,false,false);

        if (!result.Succeeded)
        {
            _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Email or Password is incorrect!");
            return false;
        }
        return true;

    }

    public async Task<bool> Register(RegisterDto registerDto)
    {
        AppUser existUser = await _userManager.FindByNameAsync(registerDto.UserName);
        if (existUser is not null)
        {
            _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "User already exist!");
            return false;

        }
        AppUser newUser = _mapper.Map<AppUser>(registerDto);
        IdentityResult result = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", item.Description);
                return false;

            }
        }
        await _userManager.AddToRoleAsync(newUser, "User");
        return true;
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
    #endregion

    #region Get Requests

    public async Task<IDataResult<List<UserGetDto>>> GetAllUser(params string[] includes)
    {
        List<AppUser> userList = GetUsers(includes).ToList();
        return new SuccessDataResult<List<UserGetDto>>(await GetUserDtos(userList));

    }

    public async Task<IDataResult<List<UserGetDto>>> GetAllUserByRole(string role, params string[] includes)
    {
        IList<AppUser> users = await _userManager.GetUsersInRoleAsync(role);
        users = GetUsers(includes).ToList();
        return new SuccessDataResult<List<UserGetDto>>(_mapper.Map<List<UserGetDto>>(users));
    }

    public async Task<IDataResult<UserGetDto>> GetUserById(string id, params string[] includes)
    {
        List<AppUser> users = GetUsers(includes).ToList();
        return new SuccessDataResult<UserGetDto>(_mapper.Map<UserGetDto>(users.Where(u => u.Id == id).FirstOrDefault()));
    }
    public async Task<IDataResult<UserGetDto>> GetUserByClaims(ClaimsPrincipal userClaims, params string[] includes)
    {
        List<AppUser> userList = GetUsers(includes).ToList();
        AppUser user = await _userManager.GetUserAsync(userClaims);
        return new SuccessDataResult<UserGetDto>(_mapper.Map<UserGetDto>(userList.Where(u => u.Id == user.Id).FirstOrDefault()));
    }


    #endregion


    #region EvokeRevoke Requests

    public async Task<IResult> EvokeUserToAdmin(UserGetDto dto)
    {
        AppUser user = await _userManager.FindByIdAsync(dto.Id);
        await _userManager.RemoveFromRoleAsync(user, "User");
        IdentityResult result = await _userManager.AddToRoleAsync(user, "Admin");
        if (!result.Succeeded)
        {
            return new ErrorResult("The user could not become an admin");
        }
        return new ErrorResult("The user is an admin now");
    }
    public async Task<IResult> RevokeFromAdmin(UserGetDto dto)
    {
        AppUser user = await _userManager.FindByIdAsync(dto.Id);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        IdentityResult result = await _userManager.AddToRoleAsync(user, "User");
        if (!result.Succeeded)
        {
            return new ErrorResult("Can't revoke the admin");
        }
        return new ErrorResult("The admin successfully revoked");
    }



    #endregion

    #region Private Methods

    private IQueryable<AppUser>GetUsers(string[] includes)
    {
        IQueryable<AppUser> users = _userManager.Users;
        if (includes is not null)
        {
            foreach (var item in includes)
            {
                users = users.Include(item);
            }
        }
        return users;
    }

    private async Task<List<UserGetDto>> GetUserDtos(List<AppUser> userList)
    {
        List<UserGetDto> users = _mapper.Map<List<UserGetDto>>(userList);
        for (int i = 0; i < userList.Count; i++)
        {
            for (int j = 0; j < users.Count; j++)
            {
                users[i].Roles = (List<string>)await _userManager.GetRolesAsync(userList[i]);
            }
        }
        return users;
    }


    #endregion





}
