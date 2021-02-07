using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Requests.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class ExpenseType: FieldBase<object, ExpenseTypeModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "expenseType";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Expense Type" }
    };

    private readonly IServiceProvider fServiceProvider;

    public ExpenseType(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ExpenseTypeModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new ExpenseTypeRequest(context.GetArgument<int>(_IdArgumentName)), context.CancellationToken);
    }
  }
}
