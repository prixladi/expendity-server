using MediatR;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.ModelValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class CreateProjectRequest: Validable<CreateProjectModel, CreateProjectModelValidator>, IRequest<ProjectModel>
  {
    public override CreateProjectModel Model { get; }

    public CreateProjectRequest(CreateProjectModel model)
    {
      Model = model;
    }
  }
}
