using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shamyr.Expendity.Server.Service.Services
{
  public interface IDbTransactionService
  {
    Task<TResult> InTransactionAsync<TResult>(Func<Task<TResult>> asyncAction, CancellationToken cancellationToken);
    Task InTransactionAsync(Func<Task> asyncAction, CancellationToken cancellationToken);
  }
}