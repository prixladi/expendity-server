using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class CreateProjectModel
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public CurrencyType CurrencyType { get; init; }
  }
}
