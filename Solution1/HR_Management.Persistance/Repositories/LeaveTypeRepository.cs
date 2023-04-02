using HR_Management.Application.Persistance.Contracts;
using HR_Management.Domain;

namespace HR_Management.Persistance.Repositories;

public class LeaveTypeRepository:GenericRepository<LeaveType>,ILeaveTypeRepository
{
    #region Constructor

    private readonly LeaveManagementDbContext _dbContext;
    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

}