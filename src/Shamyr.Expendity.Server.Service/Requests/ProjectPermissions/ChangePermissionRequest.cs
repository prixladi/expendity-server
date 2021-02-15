using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectPermissions
{
  public class ChangePermissionRequest: IProjectPermissionsPermission, IRequest<ProjectPermissionModel>
  {
    public ChangePermissionModel Model { get; }

    int IProjectPermissionsPermission.ProjectId => Model.ProjectId;
    int IProjectPermissionsPermission.UserId => Model.UserId;
    PermissionType? IProjectPermissionsPermission.SettingPermission => Model.PermissionType;
    PermissionType IProjectPermissionsPermission.RequiredPermission => PermissionType.Configure;

    public ChangePermissionRequest(ChangePermissionModel model)
    {
      Model = model;
    }
  }
}
