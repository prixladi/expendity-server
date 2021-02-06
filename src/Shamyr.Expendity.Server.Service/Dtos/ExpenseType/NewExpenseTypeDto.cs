namespace Shamyr.Expendity.Server.Service.Dtos.ExpenseType
{
  public class NewExpenseTypeDto
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; } = default!;
  }
}
