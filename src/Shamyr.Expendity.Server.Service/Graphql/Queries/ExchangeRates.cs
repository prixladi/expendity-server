using System.Threading.Tasks;
using GraphQL;
using Shamyr.Expendity.Server.Service.Models.ExchangeRate;
using Shamyr.Expendity.Server.Service.Requests.ExchangeRate;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class ExchangeRates: OperationBase<object, ExchangeRatesModel>
  {
    internal override string Name => "exchangeRates";
    internal override string? Description => "Exchange rates that could be used for as reference for exchanging between currencies.";

    internal override async Task<ExchangeRatesModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new ExchangeRatesRequest(), context.CancellationToken);
    }
  }
}
