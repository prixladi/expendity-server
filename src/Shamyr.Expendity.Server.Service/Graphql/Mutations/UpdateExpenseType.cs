using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Requests.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class UpdateExpenseType: OperationBase<object, ExpenseTypeModel>
  {
    private const string _IdArgumentName = "id";
    private const string _UpdateArgumentName = "update";

    internal override string Name => "updateExpenseType";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Expense Type" },
      new QueryArgument<NonNullGraphType<ExpenseTypeUpdateInputType>> { Name = _UpdateArgumentName }
    };

    internal override async Task<ExpenseTypeModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);
      var model = await context.GetArgumentAsync<UpdateExpenseTypeModel, UpdateExpenseTypeModelValidator>(_UpdateArgumentName, context.CancellationToken);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new UpdateExpenseTypeRequest(id, model), context.CancellationToken);
    }
  }
}
