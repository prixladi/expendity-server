using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.Project;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ProjectRepository: RepositoryBase<ProjectEntity>, IProjectRepository
  {
    public ProjectRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto, int userId, CancellationToken cancellationToken)
    {
      var entity = fMapper.Map<CreateProjectDto, ProjectEntity>(dto);

      await InTrasactionAsync(async () =>
      {
        DbSet.Add(entity);
        await fContext.SaveChangesAsync(cancellationToken);

        entity.Permissions.Add
        (
          new ProjectPermissionEntity
          {
            UserId = userId,
            ProjectId = entity.Id,
            Type = PermissionType.Own
          }
        );
        await fContext.SaveChangesAsync(cancellationToken);
      }, cancellationToken);

      // TODO: Think this over so it could be used with mapper
      return new ProjectDto
      {
        Id = entity.Id,
        Description = entity.Description,
        Name = entity.Name,
        UserPermission = PermissionType.Own
      };
    }

    public async Task<ProjectDto?> SetDeletedAsync(int id, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.Id == id)
        .SingleOrDefaultAsync(cancellationToken);

      if (entity is null)
        return null;

      entity.Deleted = true;
      await fContext.SaveChangesAsync(cancellationToken);

      // TODO: Think this over so it could be used with mapper
      return new ProjectDto
      {
        Id = entity.Id,
        Description = entity.Description,
        Name = entity.Name,
        // TODO: It will probably be allways own because no other person cound update it, but it should not rely on it
        UserPermission = PermissionType.Own
      };
    }

    public async Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto update, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.Id == id)
        .SingleOrDefaultAsync(cancellationToken);

      if (entity is null)
        return null;

      fMapper.Map(update, entity);
      await fContext.SaveChangesAsync(cancellationToken);

      // TODO: Think this over so it could be used with mapper
      return new ProjectDto
      {
        Id = entity.Id,
        Description = entity.Description,
        Name = entity.Name,
        // TODO: It will probably be allways own because no other person cound update it, but it should not rely on it
        UserPermission = PermissionType.Own
      };
    }
  }
}
