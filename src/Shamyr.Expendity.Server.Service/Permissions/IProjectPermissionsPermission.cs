using System;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Permissions
{
  public interface IProjectPermissionsPermission
  {
    // Manipulated project id
    int ProjectId { get; }

    // Manipulated user id
    int UserId { get; }

    // Permission to be set or null in case of delete
    PermissionType? SettingPermission { get; }

    public PermissionType RequiredPermission { get; }
  }
}
