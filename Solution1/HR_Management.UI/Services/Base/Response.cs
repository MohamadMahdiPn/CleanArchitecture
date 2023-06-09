﻿namespace HR_Management.UI.Services.Base;

public class Response<T>
{
    public string Message { get; set; }
    public string ValidationErrors { get; set; }
    public bool Success { get; set; }
    public T Data { get; set; }
}

public partial interface IClient
{
    public HttpClient HttpClient { get; }
    
}

public partial class Client : IClient
{
    public HttpClient HttpClient
    {
        get
        {
            return _httpClient;
        }
    }
}