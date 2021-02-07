using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Summary
{
  public class SummaryType: ObjectGraphType<SummaryModel>
  {
    public SummaryType()
    {
      Field(x => x.FullSum);
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<SummaryEntryType>>>>(nameof(SummaryModel.Entries));
    }
  }
}
