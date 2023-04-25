﻿using AutoMapper;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler:IRequestHandler<UpdateLeaveTypeCommand , Unit>
{
    #region Constructor

    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    #endregion


    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {

        var validator = new LeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto, cancellationToken);
        if (!validationResult.IsValid)
            throw new CustomValidationException(validationResult);

        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeDto.Id);
        _mapper.Map(request.LeaveTypeDto, leaveType);

        await _leaveTypeRepository.Update(leaveType);

        return Unit.Value;
    }
}