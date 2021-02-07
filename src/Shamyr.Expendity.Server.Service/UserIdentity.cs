using System.Security.Claims;

namespace Shamyr.Expendity.Server.Service
{
  public class UserIdentity: ClaimsIdentity
  {
    public int Id { get; }
    public string SubjectId { get; }
    public string Email { get; }
    public string? Username { get; init; }

    public UserIdentity(int id, string subjectId, string email, string authType)
      : base(authType)
    {
      Id = id;
      SubjectId = subjectId;
      Email = email;
    }
  }
}
