using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.Expense;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ExpenseRepository: RepositoryBase<ExpenseEntity>, IExpenseRepository
  {
    public ExpenseRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
    {
      return await DbSet.AnyAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<ExpenseDto> CreateAsync(NewExpenseDto dto, CancellationToken cancellationToken)
    {
      var entity = Mapper.Map<ExpenseEntity>(dto);

      DbSet.Add(entity);
      await Context.SaveChangesAsync(cancellationToken);

      return Mapper.Map<ExpenseDto>(entity);
    }

    public async Task<ICollection<ExpenseDto>> GetAsync(ExpenseFilterDto filter, CancellationToken cancellationToken)
    {
      return await DbSet
        .From(filter.From)
        .To(filter.To)
        .Skip(filter.Skip)
        .Take(filter.Count)
        .ProjectTo<ExpenseDto>(Mapper.ConfigurationProvider)
        .ToArrayAsync(cancellationToken);
    }

    public async Task<ExpenseDto> GetAsync(int id, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Id == id)
        .ProjectTo<ExpenseDto>(Mapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }
  }
}
