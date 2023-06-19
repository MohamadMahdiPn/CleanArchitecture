using HR_Management.UI.Models;
using HR_Management.UI.Services.Base;

namespace HR_Management.UI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVM>> GetLeaveTypes();
    Task<LeaveTypeVM> GetLeaveType(int id);
    Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType);
    Task UpdateLeaveType(LeaveTypeVM leaveType);
    Task DeleteLeaveType(LeaveTypeVM leaveType);
}