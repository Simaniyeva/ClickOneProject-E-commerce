namespace Entities.DTOs.Account;
public class UserGetDto : IDto
{
    public UserGetDto()
    {
        Roles = new();
        Reviews = new();
    }
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Roles { get; set; }

    //Relations
    public List<FavouriteGetDto> Favourities { get; set; }
    public List<ReviewGetDto> Reviews { get; set; }
}


