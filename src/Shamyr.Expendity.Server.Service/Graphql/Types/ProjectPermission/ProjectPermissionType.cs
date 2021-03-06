﻿using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ProjectPermission
{
  public class ProjectPermissionType: ObjectGraphType<ProjectPermissionModel>
  {
    public ProjectPermissionType()
    {
      Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>));
      Field(x => x.UserEmail);
      Field(x => x.UserId);
      Field(x => x.ProjectId);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ProjectPermissionModel.Type));
    }
  }
}
