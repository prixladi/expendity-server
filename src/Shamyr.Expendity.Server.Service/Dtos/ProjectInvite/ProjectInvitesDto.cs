using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectInvite
{
  public class ProjectInvitesDto
  {
    public ICollection<ProjectInviteDto> Entries { get; init; } = default!;
  }
}
