using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Currency;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Services;
using Shamyr.Extensions.Hosting;
using Shamyr.Logging;

namespace Shamyr.Expendity.Server.Service.HostedServices
{
  public class ExchangeRatesHostedService: CronServiceBase
  {
    public ExchangeRatesHostedService(IServiceProvider serviceProvider)
      : base(TimeSpan.FromHours(1), serviceProvider) { }

    protected override async Task ExecuteAsync(IServiceProvider provider, CancellationToken cancellationToken)
    {
      var exchangeRatesRepository = provider.GetRequiredService<IExchangeRatesRepository>();
      var logger = provider.GetRequiredService<ILogger>();

      var xml = await GetExchangeRatesXmlAsync(provider, cancellationToken);
      var exchangeRates = new ExchangeRates();

      foreach (var type in Enum.GetValues(typeof(CurrencyType)).Cast<CurrencyType>())
      {
        if (type == CurrencyType.EUR) // EUR is a base
          continue;

        var node = xml.SelectNodes($"//*[@currency=\"{type}\"]")?.Item(0);
        if (node is not null)
        {
          var value = decimal.Parse(node.Attributes!["rate"]!.Value);
          exchangeRates.Add(type, value);
        }
        else
        {
          logger.LogWarning(fContext, $"Unable to load exchange rate for currency '{type}'.");
        }
      }

      await exchangeRatesRepository.MergeRatesAsync(exchangeRates, cancellationToken);
    }

    private async Task<XmlDocument> GetExchangeRatesXmlAsync(IServiceProvider provider, CancellationToken cancellationToken)
    {
      var httpClientService = provider.GetRequiredService<IHttpClientService>();

      var result = await httpClientService.Client.GetAsync("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml", cancellationToken);
      var resultContent = await result.Content.ReadAsStreamAsync(cancellationToken);
      var xml = new XmlDocument();
      xml.Load(resultContent);

      return xml;
    }
  }
}
