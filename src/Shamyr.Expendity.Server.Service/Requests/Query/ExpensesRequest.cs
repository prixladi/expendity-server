using System.Collections.Generic;
using MediatR;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Requests.Query
{
  public class ExpensesRequest: IRequest<ICollection<ExpenseModel>>
  {
    public ExpenseFilterModel Model { get; }

    public ExpensesRequest(ExpenseFilterModel model)
    {
      Model = model;
    }
  }
}
