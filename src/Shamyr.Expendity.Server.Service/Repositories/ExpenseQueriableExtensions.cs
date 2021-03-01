using System;
using System.Linq;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public static class ExpenseQueriableExtensions
  {
    public static IQueryable<ExpenseEntity> From(this IQueryable<ExpenseEntity> query, DateTime? from)
    {
      if (from.HasValue)
        return query.Where(e => e.DateAdded >= from.Value);

      return query;
    }

    public static IQueryable<ExpenseEntity> To(this IQueryable<ExpenseEntity> query, DateTime? to)
    {
      if (to.HasValue)
        return query.Where(e => e.DateAdded <= to.Value);

      return query;
    }
  }
}
