using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class DeleteProjectRequest: IProjectPermission, IRequest<ProjectModel>
  {
    public int Id { get; }

    int IProjectPermission.ProjectId => Id;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Own;

    public DeleteProjectRequest(int id)
    {
      Id = id;
    }
  }
}
