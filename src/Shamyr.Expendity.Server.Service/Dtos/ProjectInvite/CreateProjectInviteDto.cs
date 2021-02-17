using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectInvite
{
  public class CreateProjectInviteDto
  {
    public PermissionType ProjectPermissionType { get; init; }
    public bool IsMultiUse { get; init; }
    public int ProjectId { get; init; }
    public string Token { get; set; } = default!;
  }
}
