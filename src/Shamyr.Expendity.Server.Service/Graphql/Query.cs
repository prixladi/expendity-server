using System;
using System.Collections.Generic;
using GraphQL.Authorization;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Queries;
using Shamyr.Expendity.Server.Service.Graphql.Types.Expense;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Graphql.Types.Summary;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class Query: ObjectGraphTypeBase<object>, IQuery
  {
    private readonly IServiceProvider fServiceProvider;

    public Query(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;

      Name = "Query";

      Register<ProjectDetailType, ProjectDetailModel>(new Project(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<ProjectsType, ProjectsModel>(new Projects(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new Expense(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ExpensesType>, ExpensesModel>(new Expenses(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new Queries.ExpenseType(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<ListGraphType<NonNullGraphType<ExpenseTypeType>>>, ICollection<ExpenseTypeModel>>(new ExpenseTypes(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);

      Register<NonNullGraphType<SummaryType>, SummaryModel>(new Summary(fServiceProvider))
        .AuthorizeWith(Constants.Auth._Authenticated);
    }
  }
}
