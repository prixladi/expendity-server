using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectInvite
{
  public class ProjectInviteRequest: IProjectInvitePermission, IRequest<ProjectInviteModel>
  {
    public int Id { get; }

    int IProjectInvitePermission.ProjectInviteId => Id;
    PermissionType IProjectInvitePermission.RequiredPermission => PermissionType.Configure;

    public ProjectInviteRequest(int id)
    {
      Id = id;
    }
  }
}
