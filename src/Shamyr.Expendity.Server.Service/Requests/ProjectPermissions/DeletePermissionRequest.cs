using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectPermissions
{
  public class DeletePermissionRequest: IProjectPermissionsPermission, IRequest<ProjectPermissionModel>
  {
    public int ProjectId { get; }
    public int UserId { get; }

    int IProjectPermissionsPermission.ProjectId => ProjectId;
    int IProjectPermissionsPermission.UserId => UserId;
    PermissionType? IProjectPermissionsPermission.SettingPermission => null;
    PermissionType IProjectPermissionsPermission.RequiredPermission => PermissionType.Configure;

    public DeletePermissionRequest(int projectId, int userId)
    {
      ProjectId = projectId;
      UserId = userId;
    }
  }
}
