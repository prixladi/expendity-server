namespace Shamyr.Expendity.Server.Service.Dtos.Users
{
  public class UserProfileDto
  {
    public string SubjectId { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string? Username { get; init; }
  }
}
