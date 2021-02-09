using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Project: OperationBase<object, ProjectDetailModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "project";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Project" }
    };

    internal override async Task<ProjectDetailModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ProjectRequest(context.GetArgument<int>(_IdArgumentName)), context.CancellationToken);
    }
  }
}
