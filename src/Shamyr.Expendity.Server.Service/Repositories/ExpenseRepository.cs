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

    public async Task<ExpenseDto> CreateAsync(CreateExpenseDto dto, CancellationToken cancellationToken)
    {
      var entity = fMapper.Map<ExpenseEntity>(dto);

      DbSet.Add(entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ExpenseDto>(entity);
    }

    public async Task<long> ChangeCurrencyAsync(int projectId, decimal rate, CancellationToken cancellationToken)
    {
      const string query = "Update expenses set value = value * {0} where project_id = {1}";
      return await fContext.Database.ExecuteSqlRawAsync(query, new object[] { rate, projectId }, cancellationToken);
    }

    public async Task<ICollection<ExpenseDto>> GetAsync(ExpenseFilterDto filter, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(x => x.ProjectId == filter.ProjectId)
        .From(filter.From)
        .To(filter.To)
        // Default order
        .OrderByDescending(e => e.AddedUtc)
        .Skip(filter.Skip)
        .Take(filter.Count)
        .ProjectTo<ExpenseDto>(fMapper.ConfigurationProvider)
        .ToArrayAsync(cancellationToken);
    }

    public async Task<ExpenseDto> GetAsync(int id, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Id == id)
        .ProjectTo<ExpenseDto>(fMapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<long> CountAsync(ExpenseFilterDto filter, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(x => x.ProjectId == filter.ProjectId)
        .From(filter.From)
        .To(filter.To)
        .LongCountAsync(cancellationToken);
    }

    public async Task<ExpenseDto?> UpdateAsync(int id, UpdateExpenseDto update, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.Id == id)
        .SingleOrDefaultAsync(cancellationToken);

      if (entity is null)
        return null;

      fMapper.Map(update, entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ExpenseEntity, ExpenseDto>(entity);
    }

    public async Task<ExpenseDto?> DeleteAsync(int id, CancellationToken cancellationToken)
    {
      var entity = await DbSet
        .Where(e => e.Id == id)
        .SingleOrDefaultAsync(cancellationToken);

      if (entity is null)
        return null;

      DbSet.Remove(entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ExpenseEntity, ExpenseDto>(entity);
    }
  }
}
