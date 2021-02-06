using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Scripts: FieldBase<object, ICollection<ExpenseModel>>
  {
    private const string _FilterArgumentName = "filter";

    internal override string Name => "expenses";

    private readonly IServiceProvider fServiceProvider;

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ExpenseFilterInputType>> { Name = _FilterArgumentName }
    };

    public Scripts(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ICollection<ExpenseModel>> ResolveAsync(IResolveFieldContext<object> context)
    {
      var filter = await context.GetArgumentAsync<ExpenseFilterModel, ExpenseFilterModelValidator>(_FilterArgumentName, context.CancellationToken);

      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new ExpensesRequest(filter), context.CancellationToken);
    }
  }
}
