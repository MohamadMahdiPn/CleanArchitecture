using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using MediatR;
using System.ComponentModel.DataAnnotations;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler:IRequestHandler<UpdateLeaveRequestCommand,Unit>
{
    #region Constructor

    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
       
    }

    #endregion

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        
        var validator = new UpdateLeaveRequestDtoValidator(_leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);
        if (!validationResult.IsValid)
            throw new CustomValidationException(validationResult);

        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (request.LeaveRequestDto != null)
        {
            _mapper.Map(request.LeaveRequestDto, leaveRequest);
            await _leaveRequestRepository.Update(leaveRequest);
        }
        else
        {
            await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest,request.ChangeLeaveRequestApprovalDto.Approved);

        }


        return Unit.Value;
    }
}