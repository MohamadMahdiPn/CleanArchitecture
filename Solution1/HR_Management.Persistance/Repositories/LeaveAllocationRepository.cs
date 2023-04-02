using HR_Management.Application.Persistance.Contracts;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistance.Repositories;

public class LeaveAllocationRepository:GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    #region Constructor

     private readonly LeaveManagementDbContext _dbContext;
    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion


    #region Get Leave Allocation With Details

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _dbContext.LeaveAllocations
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);
        return leaveAllocation;
    }


    #endregion

    #region Get Leave Allocations With Details

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _dbContext.LeaveAllocations.Include(q => q.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    #endregion

}