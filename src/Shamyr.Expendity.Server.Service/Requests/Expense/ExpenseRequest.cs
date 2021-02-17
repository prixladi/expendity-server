using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class ExpenseRequest: IExpensePermission, IRequest<ExpenseModel>
  {
    public int Id { get; }

    public int ExpenseId => Id;
    public PermissionType RequiredPermission => PermissionType.View;

    public ExpenseRequest(int id)
    {
      Id = id;
    }
  }
}
