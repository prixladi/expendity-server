using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class MeType: ObjectGraphType<MeModel>
  {
    public MeType()
    {
      Field(x => x.Id);
      Field(x => x.SubjectId);
      Field(x => x.Email);
      Field(x => x.Username);
    }
  }
}
