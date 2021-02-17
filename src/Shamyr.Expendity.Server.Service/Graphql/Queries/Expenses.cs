using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Expense;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Expenses: OperationBase<object, ExpensesModel>
  {
    private const string _FilterArgumentName = "filter";

    internal override string Name => "expenses";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ExpenseFilterInputType>> { Name = _FilterArgumentName }
    };

    internal override async Task<ExpensesModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var filter = context.GetArgument<ExpenseFilterModel>(_FilterArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ExpensesRequest(filter), context.CancellationToken);
    }
  }
}
