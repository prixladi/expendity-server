using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite
{
  public class ProjectInviteType: ObjectGraphType<ProjectInviteModel>
  {
    public ProjectInviteType()
    {
      Field(x => x.Id, type: typeof(IdGraphType));
      Field(x => x.IsMultiUse);
      Field(x => x.ProjectId);
      Field(x => x.Token);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ProjectInviteModel.ProjectPermissionType));
    }
  }
}
