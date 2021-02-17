using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ProjectRepository: RepositoryBase<ProjectEntity>, IProjectRepository
  {
    public ProjectRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<ProjectWithPermissionTypeDto?> GetByProjectAndUserIdAsync(int id, int userId, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Id == id)
        .Select(e => new
        {
          ProjectId = e.Id,
          PermissionType = e.Permissions.SingleOrDefault(e => e.UserId == userId)
        })
        .Select(dto => new ProjectWithPermissionTypeDto
        {
          ProjectId = dto.ProjectId,
          PermissionType = dto.PermissionType == null ? null : dto.PermissionType.Type
        })
        .SingleOrDefaultAsync(cancellationToken);
    }

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
        Name = entity.Name,
        Description = entity.Description,
        CurrencyType = entity.CurrencyType,
        UserPermission = PermissionType.Own
      };
    }

    // Returns old currency type
    public async Task<CurrencyType> ChangeCurrencyAsync(int projectId, CurrencyType newCurrency, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.Id == projectId)
        .SingleOrDefaultAsync(cancellationToken);

      var oldCurrency = entity.CurrencyType;

      entity.CurrencyType = newCurrency;
      await fContext.SaveChangesAsync(cancellationToken);

      return oldCurrency;
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
        // TODO: It will probably be allways own because no other person could update it, but it should not rely on it
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
