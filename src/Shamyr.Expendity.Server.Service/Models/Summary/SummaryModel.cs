using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Models.Summary
{
  public class SummaryModel
  {
    public decimal FullSum { get; init; }
    public ICollection<SummaryEntryModel> Entries { get; init; } = default!;
  }
}
