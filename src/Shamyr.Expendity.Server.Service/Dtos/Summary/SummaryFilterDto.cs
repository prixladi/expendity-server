using System;

namespace Shamyr.Expendity.Server.Service.Dtos.Summary
{
  public class SummaryFilterDto
  {
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
    public int ProjectId { get; init; }
    public int? Top { get; init; }
  }
}
