using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos
{
  public class UserPermissionDto
  {
    public int UserId { get; init; }
    public PermissionType PermissionType { get; init; }
  }
}
