using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class ProjectCurrencyChangedModel
  {
    public long ExpensesChangedCount { get; init; }
    public CurrencyType OldCurrencyType { get; init; }
    public CurrencyType NewCurrencyType { get; init; }
  }
}
