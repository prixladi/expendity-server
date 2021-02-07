using System.Collections.Generic;
using Shamyr.Expendity.Server.Service.Handers.Permissions;

namespace Shamyr.Expendity.Server.Service.Factories
{
  public interface IPermissionHandlerFactory
  {
    IEnumerable<IPermissionHandler> Create(object request);
  }
}