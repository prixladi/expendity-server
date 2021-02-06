using System;

namespace Shamyr.Expendity.Server.Service.Dtos.Summary
{
  public class SummaryFilterDto
  {
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
  }
}
