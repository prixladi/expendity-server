using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class DeleteExpense: OperationBase<object, ExpenseModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "deleteExpense";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Expense" },
    };

    internal override async Task<ExpenseModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new DeleteExpenseRequest(id), context.CancellationToken);
    }
  }
}
