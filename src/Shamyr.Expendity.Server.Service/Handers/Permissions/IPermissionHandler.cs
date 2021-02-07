using System.Threading;
using System.Threading.Tasks;

namespace Shamyr.Expendity.Server.Service.Handers.Permissions
{
  public interface IPermissionHandler
  {
    bool CanHandle(object request);
    Task HandleAsync(object request, CancellationToken cancellationToken);
  }
}
