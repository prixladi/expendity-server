using System.Collections.Generic;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExchangeRate;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ExchangeRate
{
  public class ExchangeRatesType: ObjectGraphTypeBase<ExchangeRatesModel>
  {
    public ExchangeRatesType()
    {
      Field<NonNullGraphType<CurrencyTypeType>>(nameof(ExchangeRatesModel.BaseCurrency));
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ExchangeRateType>>>, ICollection<ExchangeRateModel>>(nameof(ExchangeRatesModel.Entries));
    }
  }
}
