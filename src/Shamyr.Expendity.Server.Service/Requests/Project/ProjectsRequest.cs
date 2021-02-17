using MediatR;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.ModelValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class ProjectsRequest: Validable<ProjectFilterModel, ProjectFilterModelValidator>, IRequest<ProjectsModel>
  {
    public override ProjectFilterModel Model { get; }

    public ProjectsRequest(ProjectFilterModel model)
    {
      Model = model;
    }
  }
}
