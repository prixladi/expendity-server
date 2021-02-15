using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ExchangeRate
{
  public class ExchangeRateModel
  {
    public CurrencyType CurrencyType { get; init; }
    public decimal Rate { get; init; }
  }
}
