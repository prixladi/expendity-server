using System;

namespace Shamyr.Expendity.Server.Service.Dtos.Expense
{
  public class ExpenseFilterDto: PaginationDto
  {
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
  }
}
