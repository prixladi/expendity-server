using System.Collections.Generic;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Currency
{
  public class ExchangeRates: Dictionary<CurrencyType, decimal>
  {
    public ExchangeRates() { }

    public ExchangeRates(IDictionary<CurrencyType, decimal> dictionary)
      : base(dictionary) { }
  }
}
