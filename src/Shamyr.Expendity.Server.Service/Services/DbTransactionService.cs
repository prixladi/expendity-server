using System;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Database;

namespace Shamyr.Expendity.Server.Service.Services
{
  public class DbTransactionService: IDbTransactionService
  {
    private readonly DatabaseContext fContext;

    public DbTransactionService(DatabaseContext databaseContext)
    {
      fContext = databaseContext;
    }

    public async Task<TResult> InTransactionAsync<TResult>(Func<Task<TResult>> actionAsync, CancellationToken cancellationToken)
    {
      var transaction = await fContext.Database.BeginTransactionAsync(cancellationToken);
      try
      {
        var result = await actionAsync();
        await transaction.CommitAsync(cancellationToken);
        return result;
      }
      catch
      {
        await transaction.RollbackAsync(cancellationToken);
        throw;
      }
    }

    public async Task InTransactionAsync(Func<Task> actionAsync, CancellationToken cancellationToken)
    {
      var transaction = await fContext.Database.BeginTransactionAsync(cancellationToken);
      try
      {
        await actionAsync();
        await transaction.CommitAsync(cancellationToken);
      }
      catch
      {
        await transaction.RollbackAsync(cancellationToken);
        throw;
      }
    }
  }
}
