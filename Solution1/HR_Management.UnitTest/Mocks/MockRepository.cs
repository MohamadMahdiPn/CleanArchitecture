using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Moq;

namespace HR_Management.UnitTest.Mocks;

public static class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>()
        {
            new()
            {
                Id = 1,
                DefaultDay = 10,
                Name = "Test"
            },
            new()
            {
                Id = 2,
                DefaultDay = 0,
                Name = "Test"
            },
            new()
            {
                Id = 3,
                DefaultDay = 2,
                Name = "Test"
            },
            new()
            {
                Id = 5,
                DefaultDay = 1,
                Name = "Test"
            },
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();
        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);
        mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
            .ReturnsAsync((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return leaveType;
        });
        return mockRepo;
    }

}