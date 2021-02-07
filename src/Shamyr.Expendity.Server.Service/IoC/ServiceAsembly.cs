﻿using Microsoft.Extensions.DependencyInjection;
using Shamyr.Extensions.DependencyInjection;
using Shamyr.Expendity.Server.Service.HostedServices;
using Shamyr.Expendity.Server.Service.Handers.Permissions;

namespace Shamyr.Expendity.Server.Service.IoC
{
  internal static class ServiceAssembly
  {
    public static void AddServiceAssembly(this IServiceCollection services)
    {
      services.AddHostedService<MigrationService>();

      using IScanner scanner = services.CreateScanner<Startup>();
      scanner.AddDefaultConventions();
      scanner.AddAllTypesOf<IPermissionHandler>();
    }
  }
}
