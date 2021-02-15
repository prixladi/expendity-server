using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Currency;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IExchangeRatesRepository
  {
    Task<ExchangeRates> GetRatesAsync(CancellationToken cancellationToken);
    Task MergeRatesAsync(ExchangeRates toMerge, CancellationToken cancellationToken);
  }
}