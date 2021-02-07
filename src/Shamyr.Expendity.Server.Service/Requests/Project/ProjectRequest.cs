using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class ProjectRequest: IProjectPermission, IRequest<ProjectDetailModel>
  {
    public int Id { get; }

    int IProjectPermission.ProjectId => Id;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.View;

    public ProjectRequest(int id)
    {
      Id = id;
    }
  }
}
