using MediatR;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class ExpenseRequest: IRequest<ExpenseModel>
  {
    public int Id { get; }

    public ExpenseRequest(int id)
    {
      Id = id;
    }
  }
}
