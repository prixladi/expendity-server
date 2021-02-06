using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types;
using Shamyr.Expendity.Server.Service.Models.Summary;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Summary: FieldBase<object, SummaryModel>
  {
    private const string _FilterArgumentName = "filter";

    internal override string Name => "summary";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<SummaryFilterInputType>> { Name = _FilterArgumentName }
    };

    private readonly IServiceProvider fServiceProvider;

    public Summary(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<SummaryModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var filter = context.GetArgument<SummaryFilterModel>(_FilterArgumentName);

      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new SummaryRequest(filter), context.CancellationToken);
    }
  }
}
