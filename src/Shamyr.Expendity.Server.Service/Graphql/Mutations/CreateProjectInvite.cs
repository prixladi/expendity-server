using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class CreateProjectInvite: OperationBase<object, ProjectInviteModel>
  {
    private const string _ProjectArgumentName = "projectInvite";

    internal override string Name => "createProjectInvite";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ProjectInviteInputType>> { Name = _ProjectArgumentName, Description = "New Project Invite" }
    };

    internal override async Task<ProjectInviteModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var model = context.GetArgument<CreateProjectInviteModel>(_ProjectArgumentName);

      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new CreateProjectInviteRequest(model), context.CancellationToken);
    }
  }
}
