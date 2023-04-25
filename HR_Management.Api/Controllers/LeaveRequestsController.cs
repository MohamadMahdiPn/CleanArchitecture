using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        #region Constructor

        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion


        #region Get

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest() {Id = id});
            return Ok(leaveRequest);
        }
        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand() {LeaveRequestDto = leaveRequestDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        #endregion

        #region Put

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveRequestDto leaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand() {Id = id,};
            await _mediator.Send(command);
            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand() { Id = id};
            await _mediator.Send(command);
            return NoContent();
        }

        #endregion

    }
}
