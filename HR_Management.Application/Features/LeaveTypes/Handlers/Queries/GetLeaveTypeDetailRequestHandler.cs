﻿using AutoMapper;
using HR_Management.Application.DTOs;
using HR_Management.Application.Features.LeaveTypes.Requests;
using HR_Management.Application.Persistance.Contracts;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeDetailRequestHandler:IRequestHandler<GetLeaveTypeDetailRequest,LeaveTypeDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
        return _mapper.Map<LeaveTypeDto>(leaveType);
    }
}