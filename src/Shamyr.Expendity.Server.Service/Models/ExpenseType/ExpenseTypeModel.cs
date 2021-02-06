namespace Shamyr.Expendity.Server.Service.Models.ExpenseType
{
  public class ExpenseTypeModel
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; } = default!;
  }
}
