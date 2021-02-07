using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.Project;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IProjectPermissionRepository
  {
    Task<long> CountProjectsAsync(ProjectFilterDto filter, int userId, CancellationToken cancellationToken);
    Task<ProjectDetailDto?> GetProjectAsync(int projectId, int userId, CancellationToken cancellationToken);
    Task<ICollection<ProjectDto>> GetProjectsAsync(ProjectFilterDto filter, int userId, CancellationToken cancellationToken);
  }
}