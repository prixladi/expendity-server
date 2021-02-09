using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectInputType: InputObjectGraphType<CreateProjectModel>
  {
    public ProjectInputType()
    {
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
    }
  }
}
