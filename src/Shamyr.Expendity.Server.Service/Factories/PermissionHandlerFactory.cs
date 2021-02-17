using System;
using System.Collections.Generic;
using System.Linq;
using Shamyr.Extensions.Factories;

namespace Shamyr.Expendity.Server.Service.Factories
{
  public class PermissionHandlerFactory: FactoryBase<IPermissionValidationHandler>, IPermissionHandlerFactory
  {
    public PermissionHandlerFactory(IServiceProvider serviceProvider)
      : base(serviceProvider) { }

    public IEnumerable<IPermissionValidationHandler> Create(object request)
    {
      return GetComponents().Where(x => x.CanHandle(request));
    }
  }
}
