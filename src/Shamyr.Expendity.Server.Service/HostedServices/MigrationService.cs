using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shamyr.Logging;
using Shamyr.Expendity.Server.Service.Database;
using System;

namespace Shamyr.Expendity.Server.Service.HostedServices
{
  public class MigrationService: IHostedService
  {
    private readonly DatabaseContext fDatabaseContext;
    private readonly ILogger fLogger;

    public MigrationService(DatabaseContext databaseContext, ILogger logger)
    {
      fDatabaseContext = databaseContext;
      fLogger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      using (fLogger.TrackRequest(LoggingContext.Root, "DB migration", out var context))
      {
        try
        {
          await fDatabaseContext.Database.MigrateAsync(cancellationToken);
          fLogger.LogInformation(context, "Database migrations executed.");
          context.Success();
        }
        catch(Exception ex)
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
