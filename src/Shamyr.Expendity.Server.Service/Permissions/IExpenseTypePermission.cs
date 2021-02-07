using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Permissions
{
  public interface IExpenseTypePermission
  {
    public int ExpenseTypeId { get; }
    public PermissionType RequiredPermission { get; }
  }
}
