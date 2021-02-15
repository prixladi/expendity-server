using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Permissions
{
  public abstract class ProjectPermissionsPermissionBase: IProjectPermissionsPermission
  {
    public abstract int ProjectId { get; }
    public abstract int UserId { get; }

    bool IProjectPermissionsPermission.Validate(PermissionType userPermission, int currentUserId, out string? message)
    {
      if(UserId == currentUserId)
      {
        message = "Unable to manipulate user's own permissions.";
        return false;
      }

    }

    protected bool DoValidate(PermissionType userPermission, out string? message)
    {
      throw new System.NotImplementedException();
    }
  }
}
