using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveType;

public class CreateLeaveTypeDto: IleaveTypeDto
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}