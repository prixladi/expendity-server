using System.Threading;
using System.Threading.Tasks;

namespace Shamyr.Expendity.Server.Service.Handers.PermissionValidation
{
  public abstract class PermissionValidationHandlerBase<TRequest>: IPermissionValidationHandler
  {
    public bool CanHandle(object request)
    {
      return request is TRequest;
    }

    public Task HandleAsync(object request, CancellationToken cancellationToken)
    {
      return DoHandleAsync((TRequest)request, cancellationToken);
    }

    protected abstract Task DoHandleAsync(TRequest request, CancellationToken cancellationToken);
  }
}
