using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectInvite
{
  public class CreateProjectInviteRequest:
    Validable<CreateProjectInviteModel, CreateProjectInviteModelValidator>,
    IProjectPermission,
    IRequest<ProjectInviteModel>
  {
    public override CreateProjectInviteModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => Utils.MaxPermission(PermissionType.Configure, Model.ProjectPermissionType);

    public CreateProjectInviteRequest(CreateProjectInviteModel model)
    {
      Model = model;
    }
  }
}
