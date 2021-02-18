using System;
using System.Security.Cryptography;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service
{
  public static class Utils
  {
    // Returns bugger permission
    public static PermissionType MaxPermission(PermissionType a, PermissionType b)
    {
      return (PermissionType)Math.Max((int)a, (int)b);
    }
  }
}
