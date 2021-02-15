using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Currency;
using Shamyr.Extensions.DependencyInjection;
using Shamyr.Threading;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  [Singleton]
  public class ExchangeRatesRepository: IExchangeRatesRepository
  {
    private readonly AsyncReaderWriterLock fLock;
    private ExchangeRates fRates;

    public ExchangeRatesRepository()
    {
      fLock = new AsyncReaderWriterLock();
      fRates = new ExchangeRates();
    }

    public async Task<ExchangeRates> GetRatesAsync(CancellationToken cancellationToken)
    {
      using (await fLock.LockForReadingAsync(cancellationToken))
        return fRates;
    }

    public async Task MergeRatesAsync(ExchangeRates toMerge, CancellationToken cancellationToken)
    {
      using (await fLock.LockForWritingAsync(cancellationToken))
      {
        var newRates = new ExchangeRates(fRates);
        foreach (var rate in toMerge)
          newRates.Add(rate.Key, rate.Value);

        fRates = newRates;
      }
    }
  }
}
