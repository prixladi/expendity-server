namespace Shamyr.Expendity.Server.Service.Dtos.ExpenseType
{
  public class CreateExpenseTypeDto
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public int ProjectId { get; init; }
  }
}
