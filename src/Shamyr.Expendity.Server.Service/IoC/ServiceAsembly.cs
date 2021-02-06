using Microsoft.Extensions.DependencyInjection;
using Shamyr.Extensions.DependencyInjection;
using Shamyr.Expendity.Server.Service.HostedServices;

namespace Shamyr.Expendity.Server.Service.IoC
{
  internal static class ServiceAssembly
  {
    public static void AddServiceAssembly(this IServiceCollection services)
    {
      services.AddHostedService<MigrationService>();
      services.AddDefaultConventions<Startup>();
    }
  }
}
