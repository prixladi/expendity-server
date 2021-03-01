using System;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class ExpenseModel
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public decimal Value { get; init; }
    public string? Description { get; init; }
    public DateTime DateAdded { get; init; }
    public int? TypeId { get; init; }
    public int ProjectId { get; init; }
    public int CreatorUserId { get; init; }
    public string CreatorUserEmail { get; set; } = default!;
    public int? LastUpdaterUserId { get; init; }
    public string? LastUpdaterUserEmail { get; set; }
  }
}
