using System.Threading;
using System.Threading.Tasks;

namespace Shamyr.Expendity.Server.Service.Handers.PermissionValidation
{
  public interface IPermissionValidationHandler
  {
    bool CanHandle(object request);
    Task HandleAsync(object request, CancellationToken cancellationToken);
  }
}
