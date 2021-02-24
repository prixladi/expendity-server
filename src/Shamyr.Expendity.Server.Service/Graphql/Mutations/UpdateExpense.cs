using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Expense;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class UpdateExpense: OperationBase<object, ExpenseModel>
  {
    private const string _IdArgumentName = "id";
    private const string _UpdateArgumentName = "update";

    internal override string Name => "updateExpense";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IdGraphType>> { Name = _IdArgumentName, Description = "Id of the Expense" },
      new QueryArgument<NonNullGraphType<ExpenseUpdateInputType>> { Name = _UpdateArgumentName }
    };

    internal override async Task<ExpenseModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);
      var model = context.GetArgument<UpdateExpenseModel>(_UpdateArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new UpdateExpenseRequest(id, model), context.CancellationToken);
    }
  }
}
