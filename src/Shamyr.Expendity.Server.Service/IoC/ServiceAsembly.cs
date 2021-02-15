using Microsoft.Extensions.DependencyInjection;
using Shamyr.Expendity.Server.Service.Handers.Permissions;
using Shamyr.Expendity.Server.Service.HostedServices;
using Shamyr.Extensions.DependencyInjection;

namespace Shamyr.Expendity.Server.Service.IoC
{
  internal static class ServiceAssembly
  {
    public static void AddServiceAssembly(this IServiceCollection services)
    {
      services.AddHostedService<MigrationService>();
      services.AddHostedService<ExchangeRatesHostedService>();

      using IScanner scanner = services.CreateScanner<Startup>();
      scanner.AddDefaultConventions();
      scanner.AddAllTypesOf<IPermissionHandler>();
    }
  }
}
