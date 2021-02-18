using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ProjectPermission
{
  public class ProjectPermissionModel
  {
    public int Id { get; init; }
    public PermissionType Type { get; init; }
    public int UserId { get; init; }
    public string UserEmail { get; set; } = default!;
  }
}
