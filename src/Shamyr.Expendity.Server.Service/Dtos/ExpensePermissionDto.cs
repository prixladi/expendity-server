using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos
{
  public class ExpensePermissionDto
  {
    public PermissionType Type { get; init; }
    public int UserId { get; init; }
    public int CreatorUserId { get; init; }
  }
}
