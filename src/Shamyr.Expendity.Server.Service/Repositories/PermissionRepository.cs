using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class PermissionRepository: RepositoryBase, IPermissionRepository
  {
    public PermissionRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<PermissionType?> GetForProjectAsync(int projectId, int userId, CancellationToken cancellationToken)
    {
      return await fContext.Set<ProjectPermissionEntity>()
        .Include(e => e.Project)
        .Where(e => e.Project.Deleted == false)
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId)
        .Select(e => (PermissionType?)e.Type)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<PermissionType?> GetForExpenseTypeAsync(int expenseTypeId, int userId, CancellationToken cancellationToken)
    {
      return await fContext.Set<ExpenseTypeEntity>()
        .Where(e => e.Id == expenseTypeId)
        .Include(e => e.Project)
        .ThenInclude(e => e.Permissions)
        .Where(e => e.Project.Deleted == false)
        .SelectMany(e => e.Project.Permissions)
        .Where(e => e.UserId == userId)
        .Select(e => (PermissionType?)e.Type)
        .SingleOrDefaultAsync(cancellationToken);
    }
  }
}
