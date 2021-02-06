using Microsoft.ApplicationInsights.AspNetCore.Extensions;

namespace Shamyr.Expendity.Server.Service.Configs
{
  public static class ApplicationInsightsConfig
  {
    public static void Setup(ApplicationInsightsServiceOptions options)
    {
      options.InstrumentationKey = EnvVariable.TryGet(EnvVariables._AppInsightsKey);
      options.EnableAdaptiveSampling = false;
      options.EnableDebugLogger = false;
    }
  }
}
