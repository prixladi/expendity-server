using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class DeleteProject: OperationBase<object, ProjectModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "deleteProject";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Project" },
    };

    internal override async Task<ProjectModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new DeleteProjectRequest(id), context.CancellationToken);
    }
  }
}
