using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class DeleteExpenseRequest: IExpensePermission, IRequest<ExpenseModel>
  {
    public int Id { get; }

    int IExpensePermission.ExpenseId => Id;
    PermissionType IExpensePermission.RequiredPermission => PermissionType.Configure;
    // Creators with control permission can delete their expenses
    bool IExpensePermission.OverrideControlForCreator => true;

    public DeleteExpenseRequest(int id)
    {
      Id = id;
    }
  }
}
