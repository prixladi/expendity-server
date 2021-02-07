using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.ExpenseType
{
  public class ExpenseTypeRequest: IExpenseTypePermission, IRequest<ExpenseTypeModel>
  {
    public int Id { get; }

    int IExpenseTypePermission.ExpenseTypeId => Id;
    PermissionType IExpenseTypePermission.RequiredPermission => PermissionType.View;

    public ExpenseTypeRequest(int id)
    {
      Id = id;
    }
  }
}
