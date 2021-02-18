using System.Collections.Generic;
using Shamyr.Expendity.Server.Service.Handers.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Factories
{
  public interface IPermissionHandlerFactory
  {
    IEnumerable<IPermissionValidationHandler> Create(object request);
  }
}