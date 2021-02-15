using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.ExchangeRate;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ExchangeRate;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ExchangeRate
{
  public class ExchangeRatesRequestHandler: IRequestHandler<ExchangeRatesRequest, ExchangeRatesModel>
  {
    private readonly IExchangeRatesRepository fExchangeRatesRepository;

    public ExchangeRatesRequestHandler(IExchangeRatesRepository exchangeRatesRepository)
    {
      fExchangeRatesRepository = exchangeRatesRepository;
    }

    public async Task<ExchangeRatesModel> Handle(ExchangeRatesRequest request, CancellationToken cancellationToken)
    {
      var rates = await fExchangeRatesRepository.GetRatesAsync(cancellationToken);

      return new ExchangeRatesModel
      {
        BaseCurrency = CurrencyType.EUR,
        Entries = rates.Select(x => new ExchangeRateModel
        {
          CurrencyType = x.Key,
          Rate = x.Value
        }).ToArray()
      };
    }
  }
}
