using System;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class ExpenseModel
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public double Value { get; init; }
    public string? Description { get; init; }
    public DateTime AddedUtc { get; init; }
    public int? TypeId { get; init; }
    public int ProjectId { get; init; }
    public int CreatorUserId { get; init; }
    public string CreatorUserEmail { get; init; } = default!;
    public int? LastUpdaterUserId { get; init; }
    public string? LastUpdaterUserEmail { get; init; }
  }
}
