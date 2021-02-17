using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class AcceptProjectInvite: OperationBase<object, ProjectPermissionModel>
  {
    private const string _TokenArgumentName = "token";

    internal override string Name => "acceptProjectInvite";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _TokenArgumentName, Description = "Invite Token" }
    };

    internal override async Task<ProjectPermissionModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new AcceptProjectInviteRequest(context.GetArgument<string>(_TokenArgumentName)), context.CancellationToken);
    }
  }
}
