using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.PermissionValidation
{
  public interface IProjectInvitePermission
  {
    public int ProjectInviteId { get; }
    public PermissionType RequiredPermission { get; }
  }
}
