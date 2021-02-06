using System.Linq;
using GraphQL.Server;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql;
using Shamyr.Expendity.Server.Service.Graphql.Types;

namespace Microsoft.Extensions.DependencyInjection
{
  public static partial class ServiceCollectionExtensions
  {
    public static void AddGraphQLSchema(this IServiceCollection services)
    {
      services.AddGraphQL(options =>
      {
        options.EnableMetrics = true;
      })
#if DEBUG
      .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
#else
      .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = false)
#endif
      .AddSystemTextJson();

      services.AddSingleton<ISchemaRoot, SchemaRoot>();
      services.AddSingleton<IQuery, Query>();
      services.AddSingleton<IMutation, Mutation>();

      typeof(ExpenseInputType).Assembly.GetExportedTypes()
        .Where(type => type.Namespace!.StartsWith(typeof(ExpenseInputType).Namespace!))
        .Where(type => !type.IsAbstract && (
          typeof(ScalarGraphType).IsAssignableFrom(type) ||
          typeof(IObjectGraphType).IsAssignableFrom(type) ||
          typeof(IInputObjectGraphType).IsAssignableFrom(type)))
        .ToList()
        .ForEach(type => services.AddSingleton(type));
    }
  }
}
