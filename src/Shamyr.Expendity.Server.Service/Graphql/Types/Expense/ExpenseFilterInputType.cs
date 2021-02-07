using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Expense
{
  public class ExpenseFilterInputType: InputObjectGraphType<ExpenseFilterModel>
  {
    public ExpenseFilterInputType()
    {
      Field(x => x.Skip);
      Field(x => x.Count);
      Field(x => x.From, nullable: true);
      Field(x => x.To, nullable: true);
    }
  }
}
