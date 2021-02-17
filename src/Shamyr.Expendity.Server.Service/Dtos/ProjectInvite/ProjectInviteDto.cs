using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectInvite
{
  public class ProjectInviteDto
  {
    public int Id { get; init; }
    public int ProjectId { get; init; }
    public string Token { get; init; } = default!;
    public PermissionType ProjectPermissionType { get; init; }
    public bool IsMultiUse { get; init; }
  }
}
