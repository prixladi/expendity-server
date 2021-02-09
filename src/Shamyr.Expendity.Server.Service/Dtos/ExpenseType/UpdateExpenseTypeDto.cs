namespace Shamyr.Expendity.Server.Service.Dtos.ExpenseType
{
  public class UpdateExpenseTypeDto
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
  }
}
