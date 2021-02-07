using MediatR;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class CreateProjectRequest: IRequest<ProjectModel>
  {
    public NewProjectModel Model { get; }

    public CreateProjectRequest(NewProjectModel model)
    {
      Model = model;
    }
  }
}
