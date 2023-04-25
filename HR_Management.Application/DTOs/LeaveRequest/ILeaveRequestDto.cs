namespace HR_Management.Application.DTOs.LeaveRequest;

public interface ILeaveRequestDto
{
    public int Id { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int LeaveTypeId { get; set; }
}