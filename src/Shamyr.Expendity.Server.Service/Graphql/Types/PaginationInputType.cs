using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class PaginationInputType: InputObjectGraphType<PaginationModel>
  {
    public PaginationInputType()
    {
      Field(x => x.Skip);
      Field(x => x.Count);
    }
  }
}
