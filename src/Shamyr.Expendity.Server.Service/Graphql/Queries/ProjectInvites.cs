using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class ProjectInvites: OperationBase<object, ProjectInvitesModel>
  {
    private const string _FilterArgumentName = "filter";

    internal override string Name => "projectInvites";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ProjectInviteFilterInputType>> { Name = _FilterArgumentName }
    };

    internal override async Task<ProjectInvitesModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var filter = context.GetArgument<ProjectInviteFilterModel>(_FilterArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ProjectInvitesRequest(filter), context.CancellationToken);
    }
  }
}
