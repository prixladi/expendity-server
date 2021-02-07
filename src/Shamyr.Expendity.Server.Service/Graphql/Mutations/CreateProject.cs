using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Mutations
{
  public class CreateProject: FieldBase<object, ProjectModel>
  {
    private const string _ProjectArgumentName = "project";

    internal override string Name => "createProject";

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = _ProjectArgumentName, Description = "New Project" }
    };

    private readonly IServiceProvider fServiceProvider;

    public CreateProject(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ProjectModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var model = await context.GetArgumentAsync<NewProjectModel, NewProjectModelValidator>(_ProjectArgumentName, context.CancellationToken);

      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new CreateProjectRequest(model), context.CancellationToken);
    }
  }
}
