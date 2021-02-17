using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class UpdateProjectRequest:
    Validable<UpdateProjectModel, UpdateProjectModelValidator>,
    IProjectPermission,
    IRequest<ProjectModel>
  {
    public int Id { get; }
    public override UpdateProjectModel Model { get; }

    int IProjectPermission.ProjectId => Id;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Own;

    public UpdateProjectRequest(int id, UpdateProjectModel model)
    {
      Id = id;
      Model = model;
    }
  }
}
