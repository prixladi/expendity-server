namespace Shamyr.Expendity.Server.Service.Models.ExpenseType
{
  public class UpdateExpenseTypeModel
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
  }
}
