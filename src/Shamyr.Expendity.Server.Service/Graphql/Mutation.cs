using GraphQL.Authorization;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Mutations;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class Mutation: ObjectGraphTypeBase<object>, IMutation
  {
    public Mutation()
    {
      Name = "Mutation";

      Register<NonNullGraphType<ProjectType>, ProjectModel>(new CreateProject())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ProjectType>, ProjectModel>(new UpdateProject())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ProjectType>, ProjectModel>(new DeleteProject())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new CreateExpenseType())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new UpdateExpenseType())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new DeleteExpenseType())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new CreateExpense())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new UpdateExpense())
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new DeleteExpense())
        .AuthorizeWith(Constants.Auth._Authenticated);
    }
  }
}
