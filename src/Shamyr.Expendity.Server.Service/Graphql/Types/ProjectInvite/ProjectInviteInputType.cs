using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite
{
  public class ProjectInviteInputType: InputObjectGraphType<CreateProjectInviteModel>
  {
    public ProjectInviteInputType()
    {
      Field(x => x.IsMultiUse);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(CreateProjectInviteModel.ProjectPermissionType));
    }
  }
}
