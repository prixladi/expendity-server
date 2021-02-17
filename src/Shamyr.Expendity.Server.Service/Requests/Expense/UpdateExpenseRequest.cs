using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class UpdateExpenseRequest:
    Validable<UpdateExpenseModel, UpdateExpenseModelValidator>,
    IExpensePermission,
    IRequest<ExpenseModel>
  {
    public int Id { get; }
    public override UpdateExpenseModel Model { get; }

    int IExpensePermission.ExpenseId => Id;
    PermissionType IExpensePermission.RequiredPermission => PermissionType.Configure;
    // Creators with control permission can delete their expenses
    bool IExpensePermission.OverrideControlForCreator => true;

    public UpdateExpenseRequest(int id, UpdateExpenseModel model)
    {
      Id = id;
      Model = model;
    }
  }
}
