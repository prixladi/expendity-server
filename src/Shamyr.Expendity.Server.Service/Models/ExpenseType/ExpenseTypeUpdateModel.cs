namespace Shamyr.Expendity.Server.Service.Models.ExpenseType
{
  public class ExpenseTypeUpdateModel
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
  }
}
