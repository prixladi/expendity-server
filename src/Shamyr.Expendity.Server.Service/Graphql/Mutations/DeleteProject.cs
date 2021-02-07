using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class DeleteProject: FieldBase<object, ProjectModel>
  {
    private const string _IdArgumentName = "id";

    internal override string Name => "deleteProject";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = _IdArgumentName, Description = "Id of the Project" },
    };

    private readonly IServiceProvider fServiceProvider;

    public DeleteProject(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ProjectModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var id = context.GetArgument<int>(_IdArgumentName);

      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new DeleteProjectRequest(id), context.CancellationToken);
    }
  }
}
