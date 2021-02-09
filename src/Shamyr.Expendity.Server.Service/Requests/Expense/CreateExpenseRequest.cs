using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class CreateExpenseRequest: IProjectPermission, IRequest<ExpenseModel>
  {
    public CreateExpenseModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Control;

    public CreateExpenseRequest(CreateExpenseModel model)
    {
      Model = model;
    }
  }
}
