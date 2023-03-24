using HR_Management.Domain.Common;
using System.Security.Principal;

namespace HR_Management.Domain;

public class LeaveRequest : BaseDomainEntity
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public string RequestComment { get; set; }
    public DateTime ActionDate { get; set; }
    public bool? Approved { get; set; }
    public bool? Cancelled { get; set; }
}