using System;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class ExpenseFilterModel: PaginationModel
  {
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
    public int ProjectId { get; init; }
  }
}
