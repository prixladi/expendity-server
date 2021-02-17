using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Requests.ProjectPermissions;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class DeleteProjectPermission: OperationBase<object, ProjectPermissionModel>
  {
    private const string _ProjectIdArgumentName = "projectId";
    private const string _UserIdArgumentName = "userId";

    internal override string Name => "deleteProjectPermission";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _ProjectIdArgumentName, Description = "Id of the Project" },
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _UserIdArgumentName, Description = "Id of the User" },
    };

    internal override async Task<ProjectPermissionModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var projectId = context.GetArgument<int>(_ProjectIdArgumentName);
      var userId = context.GetArgument<int>(_UserIdArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new DeleteProjectPermissionRequest(projectId: projectId, userId: userId), context.CancellationToken);
    }
  }
}
