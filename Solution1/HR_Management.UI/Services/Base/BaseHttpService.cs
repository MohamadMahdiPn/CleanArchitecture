using System.Net.Http.Headers;
using HR_Management.UI.Contracts;

namespace HR_Management.UI.Services.Base;

public class BaseHttpService
{
    protected readonly ILocalStorageService _localStorage;
    protected readonly IClient _client;

    public BaseHttpService(ILocalStorageService localStorage, IClient client)
    {
        _localStorage = localStorage;
        _client = client;
    }

    protected Response<Guid> ConvertApiException<Guid>(ApiException apiException)
    {
        if (apiException.StatusCode == 400)
        {
            return new Response<Guid>() {Message = "Validation errors occured", Success = false, ValidationErrors = apiException.Response};
        }
        else if (apiException.StatusCode == 404)
        {
            return new Response<Guid>() { Message = "404 Not found", Success = false};
        }
        else
        {
            return new Response<Guid>() { Message = "Something wet wrong. Try again...", Success = false };

        }

    }

    protected void AddBearerToken()
    {
        if (_localStorage.Exist("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
        }
    }
}