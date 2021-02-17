using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IPermissionRepository
  {
    Task<ExpensePermissionDto> GetForExpenseAsync(int expenseId, int userId, CancellationToken cancellationToken);
    Task<PermissionType?> GetForExpenseTypeAsync(int expenseTypeId, int userId, CancellationToken cancellationToken);
    Task<UserPermissionDto[]> GetForPermissionAsync(int projectId, int userId, int currentUserId, CancellationToken cancellationToken);
    Task<PermissionType?> GetForProjectAsync(int projectId, int userId, CancellationToken cancellationToken);
    Task<PermissionType?> GetForProjectInviteAsync(int projectInviteId, int userId, CancellationToken cancellationToken);
  }
}