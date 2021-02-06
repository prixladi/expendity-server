using System;
using System.Collections.Generic;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Queries;
using Shamyr.Expendity.Server.Service.Graphql.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.Expense;
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

      Register<Types.ExpenseType, ExpenseModel>(new Expense(fServiceProvider));
      Register<NonNullGraphType<ListGraphType<NonNullGraphType<Types.ExpenseType>>>, ICollection<ExpenseModel>>(new Scripts(fServiceProvider));

      Register<ExpenseTypeType, ExpenseTypeModel>(new Queries.ExpenseType(fServiceProvider));
      Register<NonNullGraphType<ListGraphType<NonNullGraphType<ExpenseTypeType>>>, ICollection<ExpenseTypeModel>>(new Agents(fServiceProvider));

      Register<SummaryType, SummaryModel>(new Summary(fServiceProvider));
    }
  }
}
