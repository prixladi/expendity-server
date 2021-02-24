using System;
using System.Threading.Tasks;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.AspNetCore.Common;
using Microsoft.AspNetCore.Http;
using Shamyr.Expendity.Server.Service.Graphql;
using Shamyr.ExtensibleLogging;
using Shamyr.Logging;

namespace Shamyr.Expendity.Server.Service.Middleware
{
  internal class GraphqlLoggingMiddleware: GraphQLHttpMiddleware<ISchemaRoot>
  {
    private readonly ILoggingContextService fLoggingContextService;
    private readonly ILogger fLogger;

    public GraphqlLoggingMiddleware(
      RequestDelegate next,
      PathString path,
      IGraphQLRequestDeserializer deserializer,
      ILoggingContextService loggingContextService,
      ILogger logger)
      : base(next, path, deserializer)
    {
      fLoggingContextService = loggingContextService;
      fLogger = logger;
    }

    protected override Task RequestExecutedAsync(in GraphQLRequestExecutionResult requestExecutionResult)
    {
      var context = fLoggingContextService.GetRequestContext();

      if (requestExecutionResult.Result.Errors != null)
      {
        foreach (var error in requestExecutionResult.Result.Errors)
        {
          fLogger.LogException(context, error,
            $"Error while executing GraphQL operation - " +
            $"'{requestExecutionResult.Request.Query.Substring(0, Math.Min(30, requestExecutionResult.Request.Query.Length))}'...");
        }
      }

      return base.RequestExecutedAsync(requestExecutionResult);
    }
  }
}
