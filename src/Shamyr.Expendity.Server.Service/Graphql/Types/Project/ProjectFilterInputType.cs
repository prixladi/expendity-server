using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectFilterInputType: InputObjectGraphType<ProjectFilterModel>
  {
    public ProjectFilterInputType()
    {
      Field(x => x.Skip);
      Field(x => x.Count);
    }
  }
}
