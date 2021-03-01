using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Expense
{
  public class ExpenseType: ObjectGraphType<ExpenseModel>
  {
    public ExpenseType()
    {
      Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>));
      Field(x => x.Name);
      Field(x => x.Value);
      Field(x => x.Description, nullable: true);
      Field(x => x.DateAdded);
      Field(x => x.TypeId, nullable: true);
      Field(x => x.ProjectId);
      Field(x => x.CreatorUserEmail);
      Field(x => x.CreatorUserId);
      Field(x => x.LastUpdaterUserEmail, nullable: true);
      Field(x => x.LastUpdaterUserId, nullable: true);
    }
  }
}
