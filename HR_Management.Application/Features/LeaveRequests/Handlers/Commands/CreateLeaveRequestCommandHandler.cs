using AutoMapper;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Models;
using HR_Management.Application.Responses;
using HR_Management.Domain;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    #region Constructor

    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _emailSender = emailSender;
    }

    #endregion

    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            //throw new CustomValidationException(validationResult);
            response.Success = false;
            response.Message = "Creation false";
            response.Errors = validationResult.Errors.Select(q=>q.ErrorMessage).ToList();
        }


        var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = leaveRequest.Id;

        #region SendEmail

        var email = new Email()
        {
            To = "Mamad@mamad.com",
            Subject = "leave request submitted",
            Body = "body"
        };
        try
        {
            var sendResult = await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
           //log
        }
        

        #endregion

        return response;
    }
}