using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectPermission
{
  public class ProjectPermissionUpdateInputType: InputObjectGraphType<UpdateProjectPermissionModel>
  {
    public ProjectPermissionUpdateInputType()
    {
      Field<NonNullGraphType<PermissionTypeType>>(nameof(UpdateProjectPermissionModel.PermissionType));
    }
  }
}
