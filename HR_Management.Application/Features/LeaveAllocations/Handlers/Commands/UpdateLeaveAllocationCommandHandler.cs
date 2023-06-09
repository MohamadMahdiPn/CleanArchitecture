﻿using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using MediatR;
using FluentValidation;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler:IRequestHandler<UpdateLeaveAllocationCommand , Unit>
{
    #region Constructor

    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDtoValidator(_leaveAllocationRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto, cancellationToken);
        if (!validationResult.IsValid)
            throw new CustomValidationException(validationResult);

        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.LeaveAllocationDto.Id);
        _mapper.Map(request.LeaveAllocationDto, leaveAllocation);
        await _leaveAllocationRepository.Update(leaveAllocation);

        return Unit.Value;

    }
}