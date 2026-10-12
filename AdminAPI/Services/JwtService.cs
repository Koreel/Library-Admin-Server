using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Text;
using System.Security.Claims;
using AdminAPI.Context;
using AdminAPI.Models;
using AdminAPI.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdminAPI.Services;

public class JwtService
{ 

    private readonly JwtConfig _jwtConfig;
    private readonly LoginService _loginService;
    private readonly PasswordHashService _passwordHashService;
    
    
    public JwtService(
        IOptions<JwtConfig> jwtConfig,
        LoginService loginService, 
        PasswordHashService passwordHashService)
    {
        _jwtConfig = jwtConfig.Value;
        _loginService = loginService;
        _passwordHashService = passwordHashService;
    }

    public async Task<LoginResponseModel?> Authenticate(
        LoginRequestModel request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) ||
            string.IsNullOrWhiteSpace(request.Password))
        {
            return null;
        }
        
        var user = await _loginService.FindUser(request.Username);

        if (user == null)
        {
            throw new InvalidCredentialException("The username entered does not exist");
        }

        if (!_passwordHashService.VerifyPassword(request.Password, user.Credentials.PasswordHash))
        {
            throw new InvalidCredentialException("The password entered does not match");
        }
        
        var token = GenerateToken(user);
        return _loginService.CreateLoginResponse(user, token);
    }

    string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Credentials.Username.ToString()),

            new Claim(
                ClaimTypes.Name,
                user.PersonalDetails.FirstName + " " + user.PersonalDetails.LastName),

            new Claim(
                ClaimTypes.Role,
                user.Roles)
        };
        
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtConfig.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _jwtConfig.Issuer,
            claims: claims,
            audience: _jwtConfig.Audience,
            expires: DateTime.UtcNow.AddMinutes(
                _jwtConfig.TokenValidityMins),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

  
    
}