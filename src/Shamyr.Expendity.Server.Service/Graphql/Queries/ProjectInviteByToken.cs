using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class ProjectInviteByToken: OperationBase<object, ProjectInvitePreviewModel>
  {
    private const string _TokenArgumentName = "token";

    internal override string Name => "projectInvite";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _TokenArgumentName, Description = "Invite Token" }
    };

    internal override async Task<ProjectInvitePreviewModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ProjectInviteByTokenRequest(context.GetArgument<string>(_TokenArgumentName)), context.CancellationToken);
    }
  }
}
