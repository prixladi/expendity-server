using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType
{
  public class ExpenseTypeType: ObjectGraphTypeBase<ExpenseTypeModel>
  {
    public ExpenseTypeType()
    {
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
      Field(x => x.ProjectId);
    }
  }
}
