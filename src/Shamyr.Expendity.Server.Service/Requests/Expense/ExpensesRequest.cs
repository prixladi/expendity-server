using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class ExpensesRequest:
    Validable<ExpenseFilterModel, ExpenseFilterModelValidator>,
    IProjectPermission,
    IRequest<ExpensesModel>
  {
    public override ExpenseFilterModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.View;

    public ExpensesRequest(ExpenseFilterModel model)
    {
      Model = model;
    }
  }
}
