using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class ExpenseTypeInputType: InputObjectGraphType<NewExpenseTypeModel>
  {
    public ExpenseTypeInputType()
    {
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
    }
  }
}
