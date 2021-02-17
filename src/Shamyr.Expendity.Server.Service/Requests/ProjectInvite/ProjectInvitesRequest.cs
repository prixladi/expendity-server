using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectInvite
{
  public class ProjectInvitesRequest:
    Validable<ProjectInviteFilterModel, ProjectInviteFilterModelValidator>,
    IProjectPermission,
    IRequest<ProjectInvitesModel>
  {
    public override ProjectInviteFilterModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Configure;

    public ProjectInvitesRequest(ProjectInviteFilterModel model)
    {
      Model = model;
    }
  }
}
