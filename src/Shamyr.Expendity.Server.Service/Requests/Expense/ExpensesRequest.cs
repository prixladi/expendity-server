using System.Collections.Generic;
using MediatR;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Requests.Expense
{
  public class ExpensesRequest: IRequest<ExpensesModel>
  {
    public ExpenseFilterModel Model { get; }

    public ExpensesRequest(ExpenseFilterModel model)
    {
      Model = model;
    }
  }
}
