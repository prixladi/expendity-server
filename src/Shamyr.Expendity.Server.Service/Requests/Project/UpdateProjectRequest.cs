using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class UpdateProjectRequest: IProjectPermission, IRequest<ProjectModel>
  {
    public int Id { get; }
    public ProjectUpdateModel Model { get; }

    int IProjectPermission.ProjectId => Id;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Own;

    public UpdateProjectRequest(int id, ProjectUpdateModel model)
    {
      Id = id;
      Model = model;
    }
  }
}
