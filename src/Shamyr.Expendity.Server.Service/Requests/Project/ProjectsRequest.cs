using MediatR;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class ProjectsRequest: IRequest<ProjectsModel>
  {
    public ProjectFilterModel Model { get; }

    public ProjectsRequest(ProjectFilterModel model)
    {
      Model = model;
    }
  }
}
