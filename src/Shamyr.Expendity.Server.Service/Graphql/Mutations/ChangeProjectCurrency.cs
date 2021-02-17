using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class ChangeProjectCurrency: OperationBase<object, ProjectCurrencyChangedModel>
  {
    private const string _ModelArgumentName = "model";

    internal override string Name => "changeProjectCurrency";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ChangeProjectCurrencyInputType>> { Name = _ModelArgumentName }
    };

    internal override async Task<ProjectCurrencyChangedModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var model = context.GetArgument<ChangeProjectCurrencyModel>(_ModelArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ChangeProjectCurrencyRequest(model), context.CancellationToken);
    }
  }
}
