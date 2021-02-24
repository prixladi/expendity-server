using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class UpdateProject: OperationBase<object, ProjectModel>
  {
    private const string _IdArgumentName = "id";
    private const string _UpdateArgumentName = "update";

    internal override string Name => "updateProject";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IdGraphType>> { Name = _IdArgumentName, Description = "Id of the Project" },
      new QueryArgument<NonNullGraphType<ProjectUpdateInputType>> { Name = _UpdateArgumentName }
    };

    internal override async Task<ProjectModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);
      var model = context.GetArgument<UpdateProjectModel>(_UpdateArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new UpdateProjectRequest(id, model), context.CancellationToken);
    }
  }
}
