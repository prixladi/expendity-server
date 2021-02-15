using System;

namespace Shamyr.Expendity.Server.Service.Dtos.Expense
{
  public class UpdateExpenseDto
  {
    public string Name { get; init; } = default!;
    public decimal Value { get; init; }
    public string? Description { get; init; }
    public DateTime? AddedUtc { get; init; }
    public int? TypeId { get; init; }
    public int UpdaterUserId { get; set; }
  }
}
