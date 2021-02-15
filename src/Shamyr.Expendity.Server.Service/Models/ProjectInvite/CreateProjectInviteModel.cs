using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ProjectInvite
{
  public class CreateProjectInviteModel
  {
    public PermissionType ProjectPermissionType { get; init; }
    public bool IsMultiUse { get; init; }
  }
}
