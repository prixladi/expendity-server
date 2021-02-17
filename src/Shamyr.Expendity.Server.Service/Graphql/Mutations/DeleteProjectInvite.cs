using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class DeleteProjectInvite: OperationBase<object, ProjectInviteModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "deleteProjectInvite";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Project Invite" },
    };

    internal override async Task<ProjectInviteModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new DeleteProjectInviteRequest(id), context.CancellationToken);
    }
  }
}
