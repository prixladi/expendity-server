using System;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class NewExpenseModel
  {
    public string Name { get; init; } = default!;
    public double Value { get; init; }
    public string? Description { get; init; } 
    public DateTime? AddedUtc { get; init; } 
    public int? TypeId { get; init; } 
  }
}
