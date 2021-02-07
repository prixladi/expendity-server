using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectsType: ObjectGraphType<ProjectsModel>
  {
    public ProjectsType()
    {
      Field(x => x.Count);
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ProjectType>>>>(nameof(ProjectsModel.Entries));
    }
  }
}
