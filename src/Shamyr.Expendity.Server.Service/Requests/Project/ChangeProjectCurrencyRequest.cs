using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.Project
{
  public class ChangeProjectCurrencyRequest: IProjectPermission, IRequest<ProjectCurrencyChangedModel>
  {
    public ChangeProjectCurrencyModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Configure;

    public ChangeProjectCurrencyRequest(ChangeProjectCurrencyModel model)
    {
      Model = model;
    }
  }
}
