using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Queries;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Profiles;
using HR_Management.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.UnitTest.LeaveTypes.Queries;

public class GetLeaveTypeRequestHandlerTest
{
    private IMapper _mapper;
    Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;

    public GetLeaveTypeRequestHandlerTest()
    {

        _leaveTypeRepositoryMock = MockLeaveTypeRepository.GetLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile<MappingProfile>();

        });
        _mapper =mapperConfig.CreateMapper();
    }



    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypeListRequestHandler(_leaveTypeRepositoryMock.Object, _mapper);
        var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);
        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(4);
    }

}