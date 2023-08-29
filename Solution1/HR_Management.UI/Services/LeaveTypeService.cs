using AutoMapper;
using HR_Management.UI.Contracts;
using HR_Management.UI.Models;
using HR_Management.UI.Services.Base;

namespace HR_Management.UI.Services;

public class LeaveTypeService:BaseHttpService , ILeaveTypeService
{
    #region Constructor

    protected readonly ILocalStorageService _localStorage;
    protected readonly IClient _client;
    protected readonly IMapper _mapper;
    public LeaveTypeService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage, client)
    {
        _localStorage = localStorage;
        _client = client;
        _mapper = mapper;
    }

    #endregion


    #region Get

    public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
    {
        AddBearerToken();
        var leaveType = await _client.LeaveTypesGETAsync(id);
        return _mapper.Map<LeaveTypeVM>(leaveType);
    }

    public async Task<List<LeaveTypeVM>> GetLeaveTypes()
    {
        AddBearerToken();
        var leaveTypes = await _client.LeaveTypesAllAsync();
        return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
    }

    #endregion


    #region Create

     public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
    {
        try
        {
            var response = new Response<int>();
            CreateLeaveTypeDto createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(leaveType);

            AddBearerToken();

            var apiResponse =await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);

            if (apiResponse.Success)
            {
                response.Data = apiResponse.Id;
                response.Success = true;
            }
            else
            {
                foreach (var responseValidationError in apiResponse.Errors)
                {
                    response.ValidationErrors += responseValidationError + Environment.NewLine;
                }
            }
            return response;

        }
        catch (ApiException e)
        {
            return ConvertApiException<int>(e);
        }
    }

    #endregion

    #region Update  

    public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
    {
        try
        {
            LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
            AddBearerToken();
            await _client.LeaveTypesPUTAsync(id, leaveTypeDto);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiException<int>(ex);
        }
    }


    #endregion

    #region Delete

    public async Task<Response<int>> DeleteLeaveType(int id)
    {
        try
        {
            AddBearerToken();
            await _client.LeaveTypesDELETEAsync(id);
            return new Response<int> {Success = true};
        }
        catch (ApiException ex)
        {
            return ConvertApiException<int>(ex);
        }
    }

    #endregion
    
}