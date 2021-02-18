using System.Threading.Tasks;
using GraphQL;
using Shamyr.Expendity.Server.Service.Models;
using Shamyr.Expendity.Server.Service.Requests;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Me: OperationBase<object, MeModel>
  {
    internal override string Name => "me";

    internal override async Task<MeModel> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(context.RequestServices);
      return await scope.Sender.Send(new MeRequest(), context.CancellationToken);
    }
  }
}
