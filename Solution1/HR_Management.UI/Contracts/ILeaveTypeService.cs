using HR_Management.UI.Models;
using HR_Management.UI.Services.Base;

namespace HR_Management.UI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVM>> GetLeaveTypes();
    Task<LeaveTypeVM> GetLeaveTypeDetails(int id);

    Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType);
    Task<Response<int>> UpdateLeaveType(int id,LeaveTypeVM leaveType);
    Task<Response<int>> DeleteLeaveType(int id);
}