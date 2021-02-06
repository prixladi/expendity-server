using System;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Shamyr.Expendity.Server.Service.IoC
{
  internal static class ApplicationInsights
  {
    public static void AddApplicationInsights(this IServiceCollection services, Action<ApplicationInsightsServiceOptions> setupOptions)
    {
      services.AddApplicationInsightsTelemetry(setupOptions);
      services.AddApplicationInsightsLogger(RoleNames._RemoteManagerService);
    }
  }
}
