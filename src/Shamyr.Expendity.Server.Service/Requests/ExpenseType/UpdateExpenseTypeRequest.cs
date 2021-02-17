using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ExpenseType
{
  public class UpdateExpenseTypeRequest:
    Validable<UpdateExpenseTypeModel, UpdateExpenseTypeModelValidator>,
    IExpenseTypePermission,
    IRequest<ExpenseTypeModel>
  {
    public int Id { get; }
    public override UpdateExpenseTypeModel Model { get; }

    int IExpenseTypePermission.ExpenseTypeId => Id;
    PermissionType IExpenseTypePermission.RequiredPermission => PermissionType.Configure;

    public UpdateExpenseTypeRequest(int id, UpdateExpenseTypeModel model)
    {
      Id = id;
      Model = model;
    }
  }
}
