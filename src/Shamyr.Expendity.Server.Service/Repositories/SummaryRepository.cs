using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.Summary;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class SummaryRepository: RepositoryBase<ExpenseEntity>, ISummaryRepository
  {
    public SummaryRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<SummaryDto> GetAsync(SummaryFilterDto filter, CancellationToken cancellationToken)
    {
      var entries = await DbSet
        .Where(e => e.ProjectId == filter.ProjectId)
        .From(filter.From)
        .To(filter.To)
        .GroupBy(e => e.TypeId)
        .Select(e => new SummaryEntryDto
        {
          ExpenseTypeId = e.Key,
          Sum = e.Select(x => x.Value).Sum()
        }).ToArrayAsync(cancellationToken);

      return new SummaryDto
      {
        Entries = entries,
        FullSum = entries.Sum(x => x.Sum)
      };
    }
  }
}
