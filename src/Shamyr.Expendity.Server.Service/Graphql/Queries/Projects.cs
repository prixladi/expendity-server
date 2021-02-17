using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Projects: OperationBase<object, ProjectsModel>
  {
    private const string _FilterArgumentName = "filter";

    internal override string Name => "projects";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ProjectFilterInputType>> { Name = _FilterArgumentName }
    };

    internal override async Task<ProjectsModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var filter = context.GetArgument<ProjectFilterModel>(_FilterArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ProjectsRequest(filter), context.CancellationToken);
    }
  }
}
