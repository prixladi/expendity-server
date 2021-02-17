using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite
{
  public class ProjectInviteFilterInputType: InputObjectGraphType<ProjectInviteFilterModel>
  {
    public ProjectInviteFilterInputType()
    {
      Field(x => x.Count);
      Field(x => x.Skip);
      Field(x => x.ProjectId);
    }
  }
}
