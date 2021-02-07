﻿using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectPermissionType: ObjectGraphType<ProjectPermissionModel>
  {
    public ProjectPermissionType()
    {
      Field(x => x.Id);
      Field(x => x.UserEmail);
      Field(x => x.UserId);
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ProjectPermissionModel.Type));
    }
  }
}