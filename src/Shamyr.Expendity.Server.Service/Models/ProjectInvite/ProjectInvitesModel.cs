using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Models.ProjectInvite
{
  public class ProjectInvitesModel
  {
    public ICollection<ProjectInviteModel> Entries { get; init; } = default!;
  }
}
