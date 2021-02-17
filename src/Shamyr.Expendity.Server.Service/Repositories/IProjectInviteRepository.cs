using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IProjectInviteRepository
  {
    Task<long> CountAsync(ProjectInviteFilterDto dto, CancellationToken cancellationToken);
    Task<ProjectInviteDto> CreateAsync(CreateProjectInviteDto dto, CancellationToken cancellationToken);
    Task<ProjectInviteDto?> DeleteAsync(int id, CancellationToken cancellationToken);
    Task DeleteWithoutSelectAsync(int id, CancellationToken cancellationToken);
    Task<ProjectInviteDto?> GetAsync(int id, CancellationToken cancellationToken);
    Task<ICollection<ProjectInviteDto>> GetAsync(ProjectInviteFilterDto dto, CancellationToken cancellationToken);
    Task<ProjectInviteDto?> GetByTokenAsync(string token, CancellationToken cancellationToken);
    Task<ProjectInvitePreviewDto?> GetPreviewByTokenAsync(string token, CancellationToken cancellationToken);
  }
}