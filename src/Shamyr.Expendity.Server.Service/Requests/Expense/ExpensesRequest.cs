using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class ExpensesRequest: IProjectPermission, IRequest<ExpensesModel>
  {
    public ExpenseFilterModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.View;

    public ExpensesRequest(ExpenseFilterModel model)
    {
      Model = model;
    }
  }
}
