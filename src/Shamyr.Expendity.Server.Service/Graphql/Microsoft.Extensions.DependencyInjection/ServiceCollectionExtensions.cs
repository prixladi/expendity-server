using System.Linq;
using GraphQL.Authorization;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Shamyr.Expendity.Server.Service.Graphql;
using Shamyr.Expendity.Server.Service.Graphql.Types;

namespace Microsoft.Extensions.DependencyInjection
{
  public static partial class ServiceCollectionExtensions
  {
    public static void AddGraphQLSchema(this IServiceCollection services, bool exposeStackTrace)
    {
      var builder = services.AddGraphQL(options => options.EnableMetrics = true)
      .AddUserContextBuilder(context => new UserContext(context.User))
      .AddSystemTextJson();

      if (exposeStackTrace)
        builder.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);

      services.AddSingleton<ISchemaRoot, SchemaRoot>();
      services.AddSingleton<IQuery, Query>();
      services.AddSingleton<IMutation, Mutation>();

      services.AddGraphQLAuth();

      typeof(PaginationInputType).Assembly.GetExportedTypes()
        .Where(type => type.Namespace!.StartsWith(typeof(PaginationInputType).Namespace!) && !type.IsAbstract && (
          typeof(ScalarGraphType).IsAssignableFrom(type) ||
          typeof(IObjectGraphType).IsAssignableFrom(type) ||
          typeof(IInputObjectGraphType).IsAssignableFrom(type)))
        .ToList()
        .ForEach(type => services.AddSingleton(type));
    }

    private static IServiceCollection AddGraphQLAuth(this IServiceCollection services)
    {
      services.AddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
      services.AddTransient<IValidationRule, AuthorizationValidationRule>();

      services.AddTransient(_ =>
      {
        var authSettings = new AuthorizationSettings();
        authSettings.AddPolicy(Constants.Auth._Authenticated, p => p.RequireAuthenticatedUser());
        return authSettings;
      });

      return services;
    }
  }
}
