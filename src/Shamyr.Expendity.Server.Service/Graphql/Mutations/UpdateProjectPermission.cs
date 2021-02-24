using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectPermission;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Requests.ProjectPermissions;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class UpdateProjectPermission: OperationBase<object, ProjectPermissionModel>
  {
    private const string _ProjectIdArgumentName = "projectId";
    private const string _UserIdArgumentName = "userId";
    private const string _UpdateArgumentName = "update";

    internal override string Name => "updateProjectPermission";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IdGraphType>> { Name = _ProjectIdArgumentName, Description = "Id of the Project" },
      new QueryArgument<NonNullGraphType<IdGraphType>> { Name = _UserIdArgumentName, Description = "Id of the User" },
      new QueryArgument<NonNullGraphType<ProjectPermissionUpdateInputType>> { Name = _UpdateArgumentName }
    };

    internal override async Task<ProjectPermissionModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var projectId = context.GetArgument<int>(_ProjectIdArgumentName);
      var userId = context.GetArgument<int>(_UserIdArgumentName);
      var model = context.GetArgument<UpdateProjectPermissionModel>(_UpdateArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new UpdateProjectPermissionRequest(projectId: projectId, userId: userId, model), context.CancellationToken);
    }
  }
}
