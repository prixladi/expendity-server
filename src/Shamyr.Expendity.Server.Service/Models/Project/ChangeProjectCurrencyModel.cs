using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class ChangeProjectCurrencyModel
  {
    public decimal Rate { get; init; }
    public int ProjectId { get; init; }
    public CurrencyType NewCurrencyType { get; init; }
  }
}
