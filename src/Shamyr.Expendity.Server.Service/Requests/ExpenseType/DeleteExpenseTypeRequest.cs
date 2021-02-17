using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ExpenseType
{
  public class DeleteExpenseTypeRequest: IExpenseTypePermission, IRequest<ExpenseTypeModel>
  {
    public int Id { get; }

    int IExpenseTypePermission.ExpenseTypeId => Id;
    PermissionType IExpenseTypePermission.RequiredPermission => PermissionType.Configure;

    public DeleteExpenseTypeRequest(int id)
    {
      Id = id;
    }
  }
}
