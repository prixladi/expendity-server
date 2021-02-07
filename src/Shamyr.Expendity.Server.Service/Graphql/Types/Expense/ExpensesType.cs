using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Expense
{
  public class ExpensesType: ObjectGraphType<ExpensesModel>
  {
    public ExpensesType()
    {
      Field(x => x.Count);
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ExpenseType>>>>(nameof(ExpensesModel.Entries));
    }
  }
}
