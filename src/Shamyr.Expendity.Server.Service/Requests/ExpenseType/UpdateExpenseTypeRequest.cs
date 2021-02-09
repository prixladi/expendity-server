using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Permissions;

namespace Shamyr.Expendity.Server.Service.Requests.ExpenseType
{
  public class UpdateExpenseTypeRequest: IExpenseTypePermission, IRequest<ExpenseTypeModel>
  {
    public int Id { get; }
    public UpdateExpenseTypeModel Model { get; }

    int IExpenseTypePermission.ExpenseTypeId => Id;
    PermissionType IExpenseTypePermission.RequiredPermission => PermissionType.Configure;

    public UpdateExpenseTypeRequest(int id, UpdateExpenseTypeModel model)
    {
      Id = id;
      Model = model;
    }
  }
}
