namespace Shamyr.Expendity.Server.Service.Models
{
  public class MeModel
  {
    public int Id { get; init; }
    public string SubjectId { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string? Username { get; init; }
  }
}
