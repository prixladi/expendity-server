using System.Collections.Generic;

namespace Shamyr.Expendity.Server.Service.Dtos.Summary
{
  public class SummaryDto
  {
    public double FullSum { get; init; }
    public ICollection<SummaryEntryDto> Entries { get; init; } = default!;
  }
}
