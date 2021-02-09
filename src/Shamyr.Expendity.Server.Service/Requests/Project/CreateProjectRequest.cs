using MediatR;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class CreateProjectRequest: IRequest<ProjectModel>
  {
    public CreateProjectModel Model { get; }

    public CreateProjectRequest(CreateProjectModel model)
    {
      Model = model;
    }
  }
}
