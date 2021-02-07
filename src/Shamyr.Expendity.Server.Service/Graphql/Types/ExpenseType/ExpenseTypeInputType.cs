using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType
{
  public class ExpenseTypeInputType: InputObjectGraphType<NewExpenseTypeModel>
  {
    public ExpenseTypeInputType()
    {
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
      Field(x => x.ProjectId);
    }
  }
}
