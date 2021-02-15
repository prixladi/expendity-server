using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.ExchangeRate;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.ExchangeRate
{
  public class ExchangeRateType: ObjectGraphType<ExchangeRateModel>
  {
    public ExchangeRateType()
    {
      Field(x => x.Rate);
      Field<NonNullGraphType<CurrencyTypeType>>(nameof(ExchangeRateModel.CurrencyType));
    }
  }
}
