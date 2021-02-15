using System.Collections.Generic;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ExchangeRate
{
  public class ExchangeRatesModel
  {
    public CurrencyType BaseCurrency { get; init; }
    public ICollection<ExchangeRateModel> Entries { get; init; } = default!;
  }
}
