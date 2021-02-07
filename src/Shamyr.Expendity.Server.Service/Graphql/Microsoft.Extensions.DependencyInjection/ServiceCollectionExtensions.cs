using System;
using System.Linq;
using GraphQL.Authorization;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Shamyr.Expendity.Server.Service;
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
     .AddUserContextBuilder(context =>
     {
       return new UserContext(context.User);
     })
      .AddSystemTextJson()
#if DEBUG
      .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);
#else
      .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = false);
#endif

      services.AddSingleton<ISchemaRoot, SchemaRoot>();
      services.AddSingleton<IQuery, Query>();
      services.AddSingleton<IMutation, Mutation>();

      services.AddGraphQLAuth();

      typeof(PaginationInputType).Assembly.GetExportedTypes()
        .Where(type => type.Namespace!.StartsWith(typeof(PaginationInputType).Namespace!))
        .Where(type => !type.IsAbstract && (
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

      services.AddTransient(s =>
      {
        var authSettings = new AuthorizationSettings();
        authSettings.AddPolicy(Constants.Auth._Authenticated, p => p.RequireAuthenticatedUser());
        return authSettings;
      });

      return services;
    }
  }
}
