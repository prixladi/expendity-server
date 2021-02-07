namespace Shamyr.Expendity.Server.Service.Dtos.ExpenseType
{
  public class ExpenseTypeDto
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; } 
    public int ProjectId { get; init; }
  }
}
