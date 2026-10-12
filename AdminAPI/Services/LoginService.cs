using AdminAPI.Context;
using AdminAPI.Models;

namespace AdminAPI.Services;

public class LoginService
{
    private readonly UserLoginContext _userLoginContext;
    public LoginService(UserLoginContext loginContext)
    {
        _userLoginContext = loginContext;
    }

    public async Task<User> FindUser(string username)
    {
        return _userLoginContext.Users
            .FirstOrDefault(x => x.Credentials.Username == username);
    }

    public LoginResponseModel CreateLoginResponse(User user, string token)
    {
        return new LoginResponseModel
        {
            Token = token,
            Username = user.Credentials.Username,
            Role = user.Roles,
        };
    }
}
