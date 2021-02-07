using System;
using System.Collections.Generic;
using System.Security.Claims;
using GraphQL.Authorization;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class UserContext: Dictionary<string, object>, IProvideClaimsPrincipal
  {
    private readonly ClaimsPrincipal fPrincipal;

    public UserIdentity User
    {
      get
      {
        var user = fPrincipal.Identity as UserIdentity;
        return user ?? throw new InvalidOperationException("Unable to retrieve user identity in current context");
      }
    }

    ClaimsPrincipal IProvideClaimsPrincipal.User => fPrincipal;

    public UserContext(ClaimsPrincipal principal)
    {
      fPrincipal = principal;
    }
  }
}

