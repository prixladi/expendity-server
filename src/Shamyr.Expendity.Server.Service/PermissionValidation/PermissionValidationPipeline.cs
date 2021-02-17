using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Shamyr.Expendity.Server.Service.Factories;

namespace Shamyr.Expendity.Server.Service.PermissionValidation
{
  public class PermissionValidationPipeline<TRequest>: IRequestPreProcessor<TRequest>
    where TRequest : notnull
  {
    private readonly IPermissionHandlerFactory fPermissionHandlerFactory;

    public PermissionValidationPipeline(IPermissionHandlerFactory permissionHandlerFactory)
    {
      fPermissionHandlerFactory = permissionHandlerFactory;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
      var handlers = fPermissionHandlerFactory.Create(request);
      foreach (var handler in handlers)
        await handler.HandleAsync(request, cancellationToken);
    }
  }
}
