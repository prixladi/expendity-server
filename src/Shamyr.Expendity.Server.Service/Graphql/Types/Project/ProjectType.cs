using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectType: ObjectGraphType<ProjectModel>
  {
    public ProjectType()
    {
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ProjectModel.UserPermission), description: "Current user's permission for project.");
    }
  }
}
