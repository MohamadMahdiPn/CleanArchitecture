﻿using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands;

public class DeleteLeaveTypeCommandHandler:IRequestHandler<DeleteLeaveTypeCommand>
{
    #region Constructor

    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    #endregion

    public async Task Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
        if (leaveType == null)
            throw new NotFoundException(nameof(LeaveType),request.Id);
        
        await _leaveTypeRepository.Delete(leaveType);

    }
}