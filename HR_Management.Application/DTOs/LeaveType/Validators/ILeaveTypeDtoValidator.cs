using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators;

public class ILeaveTypeDtoValidator:AbstractValidator<IleaveTypeDto>
{
    public ILeaveTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} Can not be null")
            .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");

        RuleFor(x => x.DefaultDay)
            .NotEmpty().WithMessage("{PropertyName} Can not be null")
            .GreaterThan(0)
            .LessThan(100);
    }
}