using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Requests.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class DeleteExpenseType: OperationBase<object, ExpenseTypeModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "deleteExpenseType";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Expense Type" },
    };

    internal override async Task<ExpenseTypeModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new DeleteExpenseTypeRequest(id), context.CancellationToken);
    }
  }
}
