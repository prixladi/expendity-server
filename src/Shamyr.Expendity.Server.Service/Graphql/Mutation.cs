using System;
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
    private readonly IServiceProvider fServiceProvider;

    public Mutation(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;

      Name = "Mutation";

      Register<NonNullGraphType<ProjectType>, ProjectModel>(new CreateProject(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ProjectType>, ProjectModel>(new UpdateProject(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ProjectType>, ProjectModel>(new DeleteProject(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new CreateExpense(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new CreateExpenseType(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);
    }
  }
}
