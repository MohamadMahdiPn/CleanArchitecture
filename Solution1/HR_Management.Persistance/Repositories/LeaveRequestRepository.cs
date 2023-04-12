using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistance.Repositories;

public class LeaveRequestRepository:GenericRepository<LeaveRequest> , ILeaveRequestRepository
{
    #region Costructor

     private readonly LeaveManagementDbContext _dbContext;
    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

    #region Get Leave Request With Details
    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _dbContext.LeaveRequests
            .Include(q => q.LeaveType).FirstOrDefaultAsync();
        return leaveRequest;
    }

    #endregion

    #region Get Leave Requests With Details

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _dbContext.LeaveRequests
            .Include(q => q.LeaveType).ToListAsync();
        return leaveRequests;
    }

    #endregion

    #region Change Approval Status

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
    {
        leaveRequest.Approved = approvalStatus;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    #endregion

}