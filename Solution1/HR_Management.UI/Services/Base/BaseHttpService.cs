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


}