using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Projects: FieldBase<object, ProjectsModel>
  {
    private const string _FilterArgumentName = "filter";

    internal override string Name => "projects";

    private readonly IServiceProvider fServiceProvider;

    internal override QueryArguments? Arguments => new QueryArguments
    {
      new QueryArgument<NonNullGraphType<ProjectFilterInputType>> { Name = _FilterArgumentName }
    };

    public Projects(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ProjectsModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      var filter = await context.GetArgumentAsync<ProjectFilterModel, ProjectFilterModelValidator>(_FilterArgumentName, context.CancellationToken);

      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new ProjectsRequest(filter), context.CancellationToken);
    }
  }
}
