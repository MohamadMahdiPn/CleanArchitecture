using HR_Management.UI.Models;

namespace HR_Management.UI.Contracts;

public interface IAuthenticateService
{
    Task<bool> Authenticate(string email, string password);
    Task<bool> Register(RegisterVM register);
    Task Logout();
}