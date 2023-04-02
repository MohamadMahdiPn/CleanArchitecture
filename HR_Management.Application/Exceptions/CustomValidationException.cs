using FluentValidation.Results;

namespace HR_Management.Application.Exceptions;

public class CustomValidationException : ApplicationException
{
    public List<string> Errors { get; set; } = new ();

    public CustomValidationException(ValidationResult validationResult)
    {

        foreach (var err in validationResult.Errors)
        {
            Errors.Add(err.ErrorMessage);
        }
    }
}