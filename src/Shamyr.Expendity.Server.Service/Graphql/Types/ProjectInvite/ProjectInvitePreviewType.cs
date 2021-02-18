using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite
{
  public class ProjectInvitePreviewType: ObjectGraphType<ProjectInvitePreviewModel>
  {
    public ProjectInvitePreviewType()
    {
      Field(x => x.Id, type: typeof(IdGraphType));
      Field(x => x.ProjectId);
      Field(x => x.ProjectName);
      Field(x => x.ProjectDescription, nullable: true);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ProjectInvitePreviewModel.ProjectPermissionType));
    }
  }
}
