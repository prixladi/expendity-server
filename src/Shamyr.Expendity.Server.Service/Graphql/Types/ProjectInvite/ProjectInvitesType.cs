using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite
{
  public class ProjectInvitesType: ObjectGraphType<ProjectInvitesModel>
  {
    public ProjectInvitesType()
    {
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ProjectInviteType>>>>(nameof(ProjectInvitesModel.Entries));
    }
  }
}
