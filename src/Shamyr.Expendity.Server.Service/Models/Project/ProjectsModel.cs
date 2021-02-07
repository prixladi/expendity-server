using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class ProjectsModel
  {
    public long Count { get; init; }
    public ICollection<ProjectModel> Entries { get; init; } = default!;
  }
}
