using MediatR;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Requests.Mutation
{
  public class CreateExpenseTypeRequest: IRequest<ExpenseTypeModel>
  {
    public NewExpenseTypeModel Model { get; }

    public CreateExpenseTypeRequest(NewExpenseTypeModel model)
    {
      Model = model;
    }
  }
}
