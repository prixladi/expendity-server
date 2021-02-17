using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.PermissionValidation
{
  public interface IExpenseTypePermission
  {
    public int ExpenseTypeId { get; }
    public PermissionType RequiredPermission { get; }
  }
}
