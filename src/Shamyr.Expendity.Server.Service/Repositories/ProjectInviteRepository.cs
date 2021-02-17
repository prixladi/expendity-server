using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ProjectInviteRepository: RepositoryBase<ProjectInviteEntity>, IProjectInviteRepository
  {
    public ProjectInviteRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<ProjectInviteDto?> GetAsync(int id, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Id == id)
        .ProjectTo<ProjectInviteDto>(fMapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<ProjectInviteDto>> GetAsync(ProjectInviteFilterDto dto, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.ProjectId == dto.ProjectId)
        .Skip(dto.Skip)
        .Take(dto.Count)
        .ProjectTo<ProjectInviteDto>(fMapper.ConfigurationProvider)
        .ToArrayAsync(cancellationToken);
    }

    public async Task<ProjectInvitePreviewDto?> GetPreviewByTokenAsync(string token, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Token == token)
        .ProjectTo<ProjectInvitePreviewDto>(fMapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ProjectInviteDto?> GetByTokenAsync(string token, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Token == token)
        .ProjectTo<ProjectInviteDto>(fMapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task DeleteWithoutSelectAsync(int id, CancellationToken cancellationToken)
    {
      var entity = new ProjectInviteEntity
      {
        Id = id
      };

      fContext.Attach(entity);
      fContext.Remove(entity);
      await fContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<long> CountAsync(ProjectInviteFilterDto dto, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.ProjectId == dto.ProjectId)
        .LongCountAsync(cancellationToken);
    }

    public async Task<ProjectInviteDto> CreateAsync(CreateProjectInviteDto dto, CancellationToken cancellationToken)
    {
      var entity = fMapper.Map<CreateProjectInviteDto, ProjectInviteEntity>(dto);

      DbSet.Add(entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ProjectInviteEntity, ProjectInviteDto>(entity);
    }

    public async Task<ProjectInviteDto?> DeleteAsync(int id, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.Id == id)
        .SingleOrDefaultAsync(cancellationToken);

      if (entity is null)
        return null;

      DbSet.Remove(entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ProjectInviteEntity, ProjectInviteDto>(entity);
    }
  }
}
