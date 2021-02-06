﻿using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Expense: FieldBase<object, ExpenseModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "expense";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Expense" }
    };

    private readonly IServiceProvider fServiceProvider;

    public Expense(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ExpenseModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new ExpenseRequest(context.GetArgument<int>(_IdArgumentName)), context.CancellationToken);
    }
  }
}
