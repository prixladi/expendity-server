using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class CreateExpenseRequest:
    Validable<CreateExpenseModel, CreateExpenseModelValidator>,
    IProjectPermission,
    IRequest<ExpenseModel>
  {
    public override CreateExpenseModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Control;


    public CreateExpenseRequest(CreateExpenseModel model)
    {
      Model = model;
    }
  }
}
