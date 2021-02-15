using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectPermission;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectDetailType: ObjectGraphType<ProjectDetailModel>
  {
    public ProjectDetailType()
    {
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Description, nullable: true);
      Field<NonNullGraphType<CurrencyTypeType>>(nameof(ProjectDetailModel.CurrencyType));
      Field<NonNullGraphType<PermissionTypeType>>(nameof(ProjectDetailModel.UserPermission), description: "Current user's permission for project.");

      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ProjectPermissionType>>>>(nameof(ProjectDetailModel.Permissions));
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ExpenseTypeType>>>>(nameof(ProjectDetailModel.ExpenseTypes));
    }
  }
}
