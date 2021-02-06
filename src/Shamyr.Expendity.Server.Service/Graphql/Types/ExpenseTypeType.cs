using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class ExpenseTypeType: ObjectGraphTypeBase<ExpenseTypeModel>
  {
    public ExpenseTypeType()
    {
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
    }
  }
}
