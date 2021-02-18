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
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ProjectPermissionRepository: RepositoryBase<ProjectPermissionEntity>, IProjectPermissionRepository
  {
    public ProjectPermissionRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    private IQueryable<ProjectPermissionEntity> NotDeletedSet => DbSet
      .Include(e => e.Project)
      .Where(e => !e.Project.Deleted);

    public async Task<ProjectPermissionPreviewDto> CreateIfNotExistAsync(int projectId, int userId, PermissionType permissionType, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId)
        .SingleOrDefaultAsync(cancellationToken);

      if (entity is null)
      {
        entity = new ProjectPermissionEntity
        {
          ProjectId = projectId,
          UserId = userId,
          Type = permissionType
        };

        DbSet.Add(entity);
        await fContext.SaveChangesAsync(cancellationToken);
      }

      return fMapper.Map<ProjectPermissionEntity, ProjectPermissionPreviewDto>(entity);
    }

    public async Task<ProjectPermissionDto?> UpdateAsync(int projectId, int userId, UpdateProjectPermissionDto dto, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId)
        .SingleOrDefaultAsync(cancellationToken);

      fMapper.Map(dto, entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ProjectPermissionEntity, ProjectPermissionDto>(entity);
    }

    public async Task<ProjectPermissionDto?> DeleteAsync(int projectId, int userId, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.ProjectId == projectId)
        .Where(e => e.UserId == userId)
        .SingleOrDefaultAsync(cancellationToken);

      DbSet.Remove(entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ProjectPermissionEntity, ProjectPermissionDto>(entity);
    }

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
