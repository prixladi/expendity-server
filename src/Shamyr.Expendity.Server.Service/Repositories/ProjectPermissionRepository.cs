using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.Project;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ProjectPermissionRepository: RepositoryBase<ProjectPermissionEntity>, IProjectPermissionRepository
  {
    public ProjectPermissionRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    private IQueryable<ProjectPermissionEntity> NotDeletedSet => DbSet
      .Include(e => e.Project)
      .Where(e => e.Project.Deleted == false);

    public async Task<ProjectDetailDto?> GetProjectAsync(int projectId, int userId, CancellationToken cancellationToken)
    {
      return await NotDeletedSet
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId)
        .ProjectTo<ProjectDetailDto>(fMapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<ProjectDto>> GetProjectsAsync(ProjectFilterDto filter, int userId, CancellationToken cancellationToken)
    {
      return await NotDeletedSet
        .Where(e => e.UserId == userId)
        .Skip(filter.Skip)
        .Take(filter.Count)
        .ProjectTo<ProjectDetailDto>(fMapper.ConfigurationProvider)
        .ToArrayAsync(cancellationToken);
    }

    public async Task<long> CountProjectsAsync(ProjectFilterDto filter, int userId, CancellationToken cancellationToken)
    {
      return await NotDeletedSet
        .Where(e => e.UserId == userId)
        .CountAsync(cancellationToken);
    }
  }
}
