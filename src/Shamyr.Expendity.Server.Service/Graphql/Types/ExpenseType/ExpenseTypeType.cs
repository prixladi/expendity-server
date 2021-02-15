using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType
{
  public class ExpenseTypeType: ObjectGraphType<ExpenseTypeModel>
  {
    public ExpenseTypeType()
    {
      Field(x => x.Id, type: typeof(IdGraphType));
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
      Field(x => x.ProjectId);
    }
  }
}
