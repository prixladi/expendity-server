using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Models.ProjectInvite
{
  public class ProjectInvitesModel
  {
    public long Count { get; init; }
    public ICollection<ProjectInviteModel> Entries { get; init; } = default!;
  }
}
