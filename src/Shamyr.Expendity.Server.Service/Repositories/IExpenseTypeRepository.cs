using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IExpenseTypeRepository
  {
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task<ExpenseTypeDto> CreateAsync(NewExpenseTypeDto dto, CancellationToken cancellationToken);
    Task<ICollection<ExpenseTypeDto>> GetAsync(CancellationToken cancellationToken);
    Task<ExpenseTypeDto> GetAsync(int id, CancellationToken cancellationToken);
  }
}