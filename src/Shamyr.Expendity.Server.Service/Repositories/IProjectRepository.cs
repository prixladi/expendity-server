using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IProjectRepository
  {
    Task<CurrencyType> ChangeCurrencyAsync(int projectId, CurrencyType newCurrency, CancellationToken cancellationToken);
    Task<ProjectDto> CreateAsync(CreateProjectDto dto, int userId, CancellationToken cancellationToken);
    Task<ProjectWithPermissionTypeDto?> GetByProjectAndUserIdAsync(int id, int userId, CancellationToken cancellationToken);
    Task<ProjectDto?> SetDeletedAsync(int id, CancellationToken cancellationToken);
    Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto update, CancellationToken cancellationToken);
  }
}