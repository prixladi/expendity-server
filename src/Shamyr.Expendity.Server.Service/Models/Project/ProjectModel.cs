using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class ProjectModel
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public PermissionType UserPermission { get; init; }
  }
}
