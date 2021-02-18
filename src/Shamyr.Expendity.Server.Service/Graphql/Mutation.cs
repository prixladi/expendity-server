using GraphQL.Authorization;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Mutations;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectPermission;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class Mutation: ObjectGraphTypeBase<object>, IMutation
  {
    public Mutation()
    {
      Name = "Mutation";

      RegisterAuthenticated<NonNullGraphType<ProjectCurrencyChangedType>, ProjectCurrencyChangedModel>(new ChangeProjectCurrency());

      RegisterAuthenticated<NonNullGraphType<ProjectType>, ProjectModel>(new CreateProject());
      RegisterAuthenticated<NonNullGraphType<ProjectType>, ProjectModel>(new UpdateProject());
      RegisterAuthenticated<NonNullGraphType<ProjectType>, ProjectModel>(new DeleteProject());

      RegisterAuthenticated<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new CreateExpenseType());
      RegisterAuthenticated<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new UpdateExpenseType());
      RegisterAuthenticated<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new DeleteExpenseType());

      RegisterAuthenticated<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new CreateExpense());
      RegisterAuthenticated<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new UpdateExpense());
      RegisterAuthenticated<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new DeleteExpense());

      RegisterAuthenticated<NonNullGraphType<ProjectInviteType>, ProjectInviteModel>(new CreateProjectInvite());
      RegisterAuthenticated<NonNullGraphType<ProjectInviteType>, ProjectInviteModel>(new DeleteProjectInvite());
      RegisterAuthenticated<NonNullGraphType<ProjectPermissionType>, ProjectPermissionModel>(new AcceptProjectInvite());

      RegisterAuthenticated<NonNullGraphType<ProjectPermissionType>, ProjectPermissionModel>(new UpdateProjectPermission());
      RegisterAuthenticated<NonNullGraphType<ProjectPermissionType>, ProjectPermissionModel>(new DeleteProjectPermission());
    }
  }
}
