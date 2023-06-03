namespace HR_Management.UI.Services.Base;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.19.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial interface IClient
{
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<LeaveAllocationDto>> LeaveAllocationsAllAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<LeaveAllocationDto>> LeaveAllocationsAllAsync(System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveAllocationsPOSTAsync(CreateLeaveAllocationDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveAllocationsPOSTAsync(CreateLeaveAllocationDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<LeaveAllocationDto> LeaveAllocationsGETAsync(int id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<LeaveAllocationDto> LeaveAllocationsGETAsync(int id, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveAllocationsPUTAsync(int id, UpdateLeaveAllocationDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveAllocationsPUTAsync(int id, UpdateLeaveAllocationDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveAllocationsDELETEAsync(int id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveAllocationsDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<LeaveRequestDto>> LeaveRequestsAllAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<LeaveRequestDto>> LeaveRequestsAllAsync(System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveRequestsPOSTAsync(CreateLeaveRequestDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveRequestsPOSTAsync(CreateLeaveRequestDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<LeaveRequestDto> LeaveRequestsGETAsync(int id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<LeaveRequestDto> LeaveRequestsGETAsync(int id, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveRequestsPUTAsync(int id, UpdateLeaveRequestDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveRequestsPUTAsync(int id, UpdateLeaveRequestDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveRequestsDELETEAsync(int id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveRequestsDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task ChangeapprovalAsync(int id, ChangeLeaveRequestApprovalDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task ChangeapprovalAsync(int id, ChangeLeaveRequestApprovalDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<LeaveTypeDto>> LeaveTypesAllAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<LeaveTypeDto>> LeaveTypesAllAsync(System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveTypesPOSTAsync(CreateLeaveTypeDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveTypesPOSTAsync(CreateLeaveTypeDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<LeaveTypeDto> LeaveTypesGETAsync(int id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<LeaveTypeDto> LeaveTypesGETAsync(int id, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveTypesPUTAsync(int id, LeaveTypeDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveTypesPUTAsync(int id, LeaveTypeDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveTypesDELETEAsync(int id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task LeaveTypesDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

}