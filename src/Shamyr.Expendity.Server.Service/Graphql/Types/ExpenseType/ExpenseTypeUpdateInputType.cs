using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType
{
  public class ExpenseTypeUpdateInputType: InputObjectGraphType<UpdateExpenseTypeModel>
  {
    public ExpenseTypeUpdateInputType()
    {
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
    }
  }
}
