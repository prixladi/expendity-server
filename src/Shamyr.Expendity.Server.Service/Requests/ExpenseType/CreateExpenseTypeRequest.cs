using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.ExpenseType
{
  public class CreateExpenseTypeRequest:
    Validable<CreateExpenseTypeModel, CreateExpenseTypeModelValidator>,
    IProjectPermission,
    IRequest<ExpenseTypeModel>
  {
    public override CreateExpenseTypeModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.Configure;

    public CreateExpenseTypeRequest(CreateExpenseTypeModel model)
    {
      Model = model;
    }
  }
}
