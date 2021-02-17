using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Requests.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class CreateExpenseType: OperationBase<object, ExpenseTypeModel>
  {
    private const string _ExpenseTypeArgumentName = "expenseType";

    internal override string Name => "createExpenseType";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ExpenseTypeInputType>> { Name = _ExpenseTypeArgumentName, Description = "New Expense type" }
    };

    internal override async Task<ExpenseTypeModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var model = context.GetArgument<CreateExpenseTypeModel>(_ExpenseTypeArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new CreateExpenseTypeRequest(model), context.CancellationToken);
    }
  }
}
