﻿using HR_Management.Application.DTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveAllocationListRequest : IRequest<List<LeaveTypeDto>>
{

}