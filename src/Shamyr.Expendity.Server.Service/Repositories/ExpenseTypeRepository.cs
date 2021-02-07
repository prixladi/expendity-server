using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class ExpenseTypeRepository: RepositoryBase<ExpenseTypeEntity>, IExpenseTypeRepository
  {
    public ExpenseTypeRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
    {
      return DbSet.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ExpenseTypeDto> CreateAsync(NewExpenseTypeDto dto, CancellationToken cancellationToken)
    {
      var entity = fMapper.Map<ExpenseTypeEntity>(dto);

      DbSet.Add(entity);
      await fContext.SaveChangesAsync(cancellationToken);

      return fMapper.Map<ExpenseTypeDto>(entity);
    }

    public async Task<ICollection<ExpenseTypeDto>> GetAsync(CancellationToken cancellationToken)
    {
      return await DbSet
        .ProjectTo<ExpenseTypeDto>(fMapper.ConfigurationProvider)
        .ToArrayAsync(cancellationToken);
    }

    public async Task<ExpenseTypeDto> GetAsync(int id, CancellationToken cancellationToken)
    {
      return await DbSet
        .Where(e => e.Id == id)
        .ProjectTo<ExpenseTypeDto>(fMapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);
    }
  }
}
