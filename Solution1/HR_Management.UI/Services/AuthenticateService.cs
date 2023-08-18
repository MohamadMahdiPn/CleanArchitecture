using HR_Management.UI.Contracts;
using HR_Management.UI.Services.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HR_Management.UI.Services;

public class AuthenticateService:BaseHttpService, IAuthenticateService 
{
    #region Constructor

    private readonly IHttpContextAccessor _contextAccessor;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public AuthenticateService(ILocalStorageService localStorage, IClient client, IHttpContextAccessor contextAccessor) : base(localStorage, client)
    {
        _contextAccessor = contextAccessor;
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    #endregion


    public async Task<bool> Authenticate(string email, string password)
    {
        try
        {
            AuthRequest authenticateRequest = new AuthRequest()
            {
                Email = email,
                Password = password
            };
            var authenticateResponse = await _client.LoginAsync(authenticateRequest);
            if (authenticateResponse.Token != string.Empty)
            {
                var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticateResponse.Token);
                var claims = ParseClaims(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme));
                var login =  _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                _localStorage.SetStorageValue("token",authenticateResponse.Token);
                
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Register(string firstName, string lastName, string email, string password)
    {
        RegistrationRequest registrationRequest = new()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password

        };
        var response = await _client.RegisterAsync(registrationRequest);
        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }

    public async Task Logout()
    {
      _localStorage.ClearStorage(new List<string>(){"token"});
      await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    private IList<Claim> ParseClaims(JwtSecurityToken token)
    {
        var claims = token.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name , token.Subject));
        return claims;
    }
}