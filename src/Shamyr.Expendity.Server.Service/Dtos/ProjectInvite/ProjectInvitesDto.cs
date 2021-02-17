using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectInvite
{
  public class ProjectInvitesDto
  {
    public long Count { get; init; }
    public ICollection<ProjectInviteDto> Entries { get; init; } = default!;
  }
}
