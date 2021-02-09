using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Expense;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class CreateExpense: OperationBase<object, ExpenseModel>
  {
    private const string _ExpenseArgumentName = "expense";

    internal override string Name => "createExpense";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ExpenseInputType>> { Name = _ExpenseArgumentName, Description = "New Expense" }
    };

    internal override async Task<ExpenseModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var model = await context.GetArgumentAsync<CreateExpenseModel, CreateExpenseModelValidator>(_ExpenseArgumentName, context.CancellationToken);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new CreateExpenseRequest(model), context.CancellationToken);
    }
  }
}
