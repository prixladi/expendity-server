using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.ExpenseType
{
  public class CreateExpenseTypeRequest: IProjectPermission, IRequest<ExpenseTypeModel>
  {
    public CreateExpenseTypeModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Configure;

    public CreateExpenseTypeRequest(CreateExpenseTypeModel model)
    {
      Model = model;
    }
  }
}
