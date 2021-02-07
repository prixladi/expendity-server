using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IPermissionRepository
  {
    Task<PermissionType?> GetForExpenseTypeAsync(int expenseTypeId, int userId, CancellationToken cancellationToken);
    Task<PermissionType?> GetForProjectAsync(int projectId, int userId, CancellationToken cancellationToken);
  }
}