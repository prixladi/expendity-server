using System;

namespace Shamyr.Expendity.Server.Service.Dtos.Expense
{
  public class CreateExpenseDto
  {
    public string Name { get; init; } = default!;
    public decimal Value { get; init; }
    public string? Description { get; init; }
    public DateTime DateAdded { get; init; }
    public int? TypeId { get; init; }
    public int ProjectId { get; init; }
    public int CreatorUserId { get; set; }
  }
}
