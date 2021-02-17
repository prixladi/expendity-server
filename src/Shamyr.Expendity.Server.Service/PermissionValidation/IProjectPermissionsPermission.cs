using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.PermissionValidation
{
  public interface IProjectPermissionsPermission
  {
    // Manipulated project id
    int ProjectId { get; }

    // Manipulated user id
    int UserId { get; }

    public PermissionType RequiredPermission { get; }
  }
}
