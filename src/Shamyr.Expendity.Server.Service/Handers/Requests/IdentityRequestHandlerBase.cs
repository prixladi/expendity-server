using System;
using Shamyr.Cloud.Authority.Client.Services;

namespace Shamyr.Expendity.Server.Service.Handers.Requests
{
  public abstract class IdentityRequestHandlerBase
  {
    private readonly IClaimsIdentityService fClaimsIdentityService;

    protected UserIdentity GetIdentity()
    {
      return fClaimsIdentityService.GetCurrentUser<UserIdentity>();
    }

    protected IdentityRequestHandlerBase(IClaimsIdentityService claimsIdentityService)
    {
      fClaimsIdentityService = claimsIdentityService;
    }
  }
}
