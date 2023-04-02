﻿using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveRequest;

public class UpdateLeaveRequestDto:BaseDto
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComment { get; set; }
    public bool? Cancelled { get; set; }
}