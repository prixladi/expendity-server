using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Summary
{
  public class SummaryEntryType: ObjectGraphType<SummaryEntryModel>
  {
    public SummaryEntryType()
    {
      Field(x => x.Sum);
      Field(x => x.ExpenseTypeId, nullable: true);
    }
  }
}
