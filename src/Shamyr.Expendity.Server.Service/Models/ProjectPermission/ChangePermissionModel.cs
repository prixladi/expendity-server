using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ProjectPermission
{
  public class ChangePermissionModel
  {
    public int ProjectId { get; init; }
    public int UserId { get; init; }
    public PermissionType PermissionType { get; init; }
  }
}
