using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IProjectPermissionRepository
  {
    Task<long> CountProjectsAsync(ProjectFilterDto filter, int userId, CancellationToken cancellationToken);
    Task<ProjectPermissionDto?> CreateAsync(int projectId, int userId, PermissionType permissionType, CancellationToken cancellationToken);
    Task<ProjectPermissionDto?> DeleteAsync(int projectId, int userId, CancellationToken cancellationToken);
    Task<ProjectDetailDto?> GetProjectAsync(int projectId, int userId, CancellationToken cancellationToken);
    Task<ICollection<ProjectDto>> GetProjectsAsync(ProjectFilterDto filter, int userId, CancellationToken cancellationToken);
    Task<ProjectPermissionDto?> UpdateAsync(int projectId, int userId, UpdateProjectPermissionDto dto, CancellationToken cancellationToken);
  }
}