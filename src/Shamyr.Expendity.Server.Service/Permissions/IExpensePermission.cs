using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Permissions
{
  public interface IExpensePermission
  {
    public int ExpenseId { get; }
    public PermissionType RequiredPermission { get; }
    public bool OverrideControlForCreator => false;
  }
}
