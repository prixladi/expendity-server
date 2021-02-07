using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Permissions
{
  public interface IProjectPermission
  {
    public int ProjectId { get; }
    public PermissionType RequiredPermission { get; }
  }
}
