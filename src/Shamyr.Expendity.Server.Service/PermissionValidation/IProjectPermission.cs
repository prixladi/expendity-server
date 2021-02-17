using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.PermissionValidation
{
  public interface IProjectPermission
  {
    public int ProjectId { get; }
    public PermissionType RequiredPermission { get; }
  }
}
