using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectPermission
{
  public class ChangePermissionInputType: InputObjectGraphType<ChangePermissionModel>
  {
    public ChangePermissionInputType()
    {
      Field(x => x.ProjectId);
      Field(x => x.UserId);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ChangePermissionModel.PermissionType));
    }
  }
}
