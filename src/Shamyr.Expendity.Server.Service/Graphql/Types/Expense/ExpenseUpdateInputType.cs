using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Expense
{
  public class ExpenseUpdateInputType: InputObjectGraphType<UpdateExpenseModel>
  {
    public ExpenseUpdateInputType()
    {
      Field(x => x.Name);
      Field(x => x.Value);
      Field(x => x.Description, nullable: true);
      Field(x => x.TypeId, nullable: true);
      Field(x => x.DateAdded);
    }
  }
}
