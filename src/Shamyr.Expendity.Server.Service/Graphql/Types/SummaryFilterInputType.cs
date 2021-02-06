using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class SummaryFilterInputType: InputObjectGraphType<SummaryFilterModel>
  {
    public SummaryFilterInputType()
    {
      Field(x => x.From, nullable: true);
      Field(x => x.To, nullable: true);
    }
  }
}
