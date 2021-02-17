using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Factories
{
  public interface IPermissionHandlerFactory
  {
    IEnumerable<IPermissionValidationHandler> Create(object request);
  }
}