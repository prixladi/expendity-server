using MediatR;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Requests.Mutation
{
  public class CreateExpenseRequest: IRequest<ExpenseModel>
  {
    public NewExpenseModel Model { get; }

    public CreateExpenseRequest(NewExpenseModel model)
    {
      Model = model;
    }
  }
}
