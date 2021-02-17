using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectPermission
{
  public class ProjectWithPermissionTypeDto
  {
    public int ProjectId { get; init; }
    public PermissionType? PermissionType { get; init; }
  }
}
