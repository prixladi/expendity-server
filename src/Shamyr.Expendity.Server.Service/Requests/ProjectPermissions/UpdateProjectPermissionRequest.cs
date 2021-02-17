using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectPermissions
{
  public class UpdateProjectPermissionRequest:
    Validable<UpdateProjectPermissionModel, UpdateProjectPermissionModelValidator>,
    IProjectPermissionsPermission,
    IRequest<ProjectPermissionModel>
  {
    public override UpdateProjectPermissionModel Model { get; }
    public int ProjectId { get; }
    public int UserId { get; }

    int IProjectPermissionsPermission.ProjectId => ProjectId;
    int IProjectPermissionsPermission.UserId => UserId;
    PermissionType IProjectPermissionsPermission.RequiredPermission => Utils.MaxPermission(PermissionType.Configure, Model.PermissionType);

    public UpdateProjectPermissionRequest(int projectId, int userId, UpdateProjectPermissionModel model)
    {
      ProjectId = projectId;
      UserId = userId;
      Model = model;
    }
  }
}
