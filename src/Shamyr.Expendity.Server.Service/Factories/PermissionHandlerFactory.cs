using System;
using System.Collections.Generic;
using System.Linq;
using Shamyr.Expendity.Server.Service.Handers.Permissions;
using Shamyr.Extensions.Factories;

namespace Shamyr.Expendity.Server.Service.Factories
{
  public class PermissionHandlerFactory: FactoryBase<IPermissionHandler>, IPermissionHandlerFactory
  {
    public PermissionHandlerFactory(IServiceProvider serviceProvider)
      : base(serviceProvider) { }

    public IEnumerable<IPermissionHandler> Create(object request)
    {
      return GetComponents().Where(x => x.CanHandle(request));
    }
  }
}
