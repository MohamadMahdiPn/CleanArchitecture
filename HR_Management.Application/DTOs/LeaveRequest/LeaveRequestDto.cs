using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Domain;
using HR_Management.Domain.Common;

namespace HR_Management.Application.DTOs.LeaveRequest;

public class LeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public string RequestComment { get; set; }
    public DateTime? ActionDate { get; set; }
    public bool? Approved { get; set; }
    public bool? Cancelled { get; set; }
}