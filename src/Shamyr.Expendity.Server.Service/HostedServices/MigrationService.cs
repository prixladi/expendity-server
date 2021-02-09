using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Logging;

namespace Shamyr.Expendity.Server.Service.HostedServices
{
  public class MigrationService: IHostedService
  {
    private readonly IServiceProvider fServiceProvider;
    private readonly ILogger fLogger;

    public MigrationService(IServiceProvider serviceProvider, ILogger logger)
    {
      fServiceProvider = serviceProvider;
      fLogger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      using (fLogger.TrackRequest(LoggingContext.Root, "DB migration", out var context))
      {
        try
        {
          using var scope = fServiceProvider.CreateScope();
          var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
          await dbContext.Database.MigrateAsync(cancellationToken);

          fLogger.LogInformation(context, "Database migrations executed.");
          context.Success();
        }
        catch (Exception ex)
        {
          fLogger.LogException(context, ex);
          context.Fail();
          throw;
        }
      }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }
  }
}
