using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class ExpensesModel
  {
    public long Count { get; init; }
    public ICollection<ExpenseModel> Entries { get; init; } = default!;
  }
}
