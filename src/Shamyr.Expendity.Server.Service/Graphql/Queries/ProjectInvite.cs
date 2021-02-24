using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class ProjectInvite: OperationBase<object, ProjectInviteModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "projectInvite";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IdGraphType>> { Name = _IdArgumentName, Description = "Id of the Project Invite" }
    };

    internal override async Task<ProjectInviteModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ProjectInviteRequest(context.GetArgument<int>(_IdArgumentName)), context.CancellationToken);
    }
  }
}
