using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.Responses;
using HR_Management.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.UnitTest.LeaveTypes.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    private IMapper _mapper;
    Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
    CreateLeaveTypeDto _leaveTypeDto;
    public CreateLeaveTypeCommandHandlerTests()
    {
        _leaveTypeRepositoryMock = MockLeaveTypeRepository.GetLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile<MappingProfile>();

        });
        _mapper = mapperConfig.CreateMapper();
        _leaveTypeDto = new()
        {
            DefaultDay = 15,
            Name = "TestDto"
        };
    }

    [Fact]
    public async Task CreateLeaveType()
    {
        var handler = new CreateLeaveTypeCommandHandler(_leaveTypeRepositoryMock.Object, _mapper);
        var result = await handler.Handle(new CreateLeaveTypeCommand()
        {
            LeaveTypeDto = _leaveTypeDto
        }, CancellationToken.None);
        result.ShouldBeOfType<BaseCommandResponse>();
        var leaveTypes = await _leaveTypeRepositoryMock.Object.GetAll();
        leaveTypes.Count.ShouldBe(5);
    }
}