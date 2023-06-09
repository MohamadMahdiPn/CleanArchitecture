﻿using FluentValidation;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator:AbstractValidator<CreateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveTypeRepository)
    {
        _leaveRequestRepository = leaveTypeRepository;
        Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));
        
        //RuleFor(p => p.FromDate)
        //    .LessThan(p => p.ToDate)
        //    .WithMessage("{PropertyName} must be before {ComparisonValue}");

        //RuleFor(p => p.ToDate)
        //    .GreaterThan(p => p.FromDate)
        //    .WithMessage("{PropertyName} must be after {ComparisonValue}");

        //RuleFor(p => p.LeaveTypeId)
        //    .GreaterThan(0)
        //    .MustAsync(async (id, token) =>
        //    {
        //        var leaveTypeExist = await _leaveTypeRepository.Exist(id);
        //        return !leaveTypeExist;
        //    })
        //    .WithMessage("{PropertyName} does not exist.");
    }

}