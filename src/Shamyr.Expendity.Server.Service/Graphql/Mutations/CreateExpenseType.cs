using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Requests.Mutation;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class CreateExpenseType: FieldBase<object, ExpenseTypeModel>
  {
    private const string _ExpenseTypeArgumentName = "expenseType";

    internal override string Name => "createExpenseType";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ExpenseTypeInputType>> { Name = _ExpenseTypeArgumentName, Description = "New Expense type" }
    };

    private readonly IServiceProvider fServiceProvider;

    public CreateExpenseType(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ExpenseTypeModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var model = await context.GetArgumentAsync<NewExpenseTypeModel, NewExpenseTypeModelValidator>(_ExpenseTypeArgumentName, context.CancellationToken);

      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new CreateExpenseTypeRequest(model), context.CancellationToken);
    }
  }
}
