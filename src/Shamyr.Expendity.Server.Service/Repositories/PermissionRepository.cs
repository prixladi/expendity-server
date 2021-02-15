using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos;

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
        .Where(e => !e.Project.Deleted)
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId)
        .Select(e => (PermissionType?)e.Type)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<UserPermissionDto[]> GetForPermissionAsync(int projectId, int userId, int currentUserId, CancellationToken cancellationToken)
    {
      return await fContext.Set<ProjectPermissionEntity>()
        .Include(e => e.Project)
        .Where(e => !e.Project.Deleted)
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId || e.UserId == currentUserId)
        .Select(e => new UserPermissionDto {  UserId = e.UserId, PermissionType = e.Type })
        .ToArrayAsync(cancellationToken);
    }

    public async Task<PermissionType?> GetForExpenseTypeAsync(int expenseTypeId, int userId, CancellationToken cancellationToken)
    {
      return await fContext.Set<ExpenseTypeEntity>()
        .Where(e => e.Id == expenseTypeId)
        .Include(e => e.Project)
        .ThenInclude(e => e.Permissions)
        .Where(e => !e.Project.Deleted)
        .SelectMany(e => e.Project.Permissions)
        .Where(e => e.UserId == userId)
        .Select(e => (PermissionType?)e.Type)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ExpensePermissionDto> GetForExpenseAsync(int expenseId, int userId, CancellationToken cancellationToken)
    {
      return await fContext.Set<ExpenseEntity>()
        .Where(e => e.Id == expenseId)
        .Include(e => e.Project)
        .ThenInclude(e => e.Permissions)
        .Where(e => !e.Project.Deleted)
        .SelectMany(e => e.Project.Permissions, (e, p) => new ExpensePermissionDto
        {
          CreatorUserId = e.CreatorUserId,
          Type = p.Type,
          UserId = p.UserId
        })
        .Where(dto => dto.UserId == userId)
        .SingleOrDefaultAsync(cancellationToken);
    }
  }
}
