﻿using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators;

public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeDto>
{
    public UpdateLeaveTypeValidator()
    {
        Include(new LeaveTypeDtoValidator());

        RuleFor(p => p.Id).NotNull()
            .WithMessage("{PropertyName} is required.");
    }
}