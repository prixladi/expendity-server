using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectPermissions
{
  public class DeleteProjectPermissionRequest: IProjectPermissionsPermission, IRequest<ProjectPermissionModel>
  {
    public int ProjectId { get; }
    public int UserId { get; }

    int IProjectPermissionsPermission.ProjectId => ProjectId;
    int IProjectPermissionsPermission.UserId => UserId;
    PermissionType IProjectPermissionsPermission.RequiredPermission => PermissionType.Configure;

    public DeleteProjectPermissionRequest(int projectId, int userId)
    {
      ProjectId = projectId;
      UserId = userId;
    }
  }
}
