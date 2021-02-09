namespace Shamyr.Expendity.Server.Service.Dtos.Project
{
  public class CreateProjectDto
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
  }
}
