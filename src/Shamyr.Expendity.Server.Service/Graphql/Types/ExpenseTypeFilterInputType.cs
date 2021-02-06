using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class ExpenseTypeFilterInputType: InputObjectGraphType<ExpenseTypeFilterModel>
  {
    public ExpenseTypeFilterInputType()
    {
      Field(x => x.Skip);
      Field(x => x.Count);
    }
  }
}
