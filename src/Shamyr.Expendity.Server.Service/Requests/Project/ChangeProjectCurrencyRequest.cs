using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class ChangeProjectCurrencyRequest:
    Validable<ChangeProjectCurrencyModel, ChangeProjectCurrencyModelValidator>,
    IProjectPermission,
    IRequest<ProjectCurrencyChangedModel>
  {
    public override ChangeProjectCurrencyModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Configure;

    public ChangeProjectCurrencyRequest(ChangeProjectCurrencyModel model)
    {
      Model = model;
    }
  }
}
