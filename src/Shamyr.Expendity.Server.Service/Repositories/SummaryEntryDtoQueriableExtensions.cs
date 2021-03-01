using System;
using System.Linq;
using Shamyr.Expendity.Server.Service.Dtos.Summary;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public static class SummaryEntryDtoQueriableExtensions
  {
    public static IQueryable<SummaryEntryDto> Top(this IQueryable<SummaryEntryDto> query, int? top)
    {
      if (top.HasValue)
        return query.Skip(0).Take(top.Value);

      return query;
    }
  }
}
