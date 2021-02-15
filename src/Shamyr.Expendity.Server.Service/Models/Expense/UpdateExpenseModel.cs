using System;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class UpdateExpenseModel
  {
    public string Name { get; init; } = default!;
    public decimal Value { get; init; }
    public string? Description { get; init; }
    public DateTime? AddedUtc { get; init; }
    public int? TypeId { get; init; }
  }
}
