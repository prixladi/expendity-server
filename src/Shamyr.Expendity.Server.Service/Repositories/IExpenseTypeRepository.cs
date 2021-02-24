using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IExpenseTypeRepository
  {
    Task<ExpenseTypeDto> CreateAsync(CreateExpenseTypeDto dto, CancellationToken cancellationToken);
    Task<ICollection<ExpenseTypeDto>> GetAsync(CancellationToken cancellationToken);
    Task<ExpenseTypeDto?> GetAsync(int id, CancellationToken cancellationToken);
    Task<ExpenseTypeDto?> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<ExpenseTypeDto?> UpdateAsync(int id, UpdateExpenseTypeDto update, CancellationToken cancellationToken);
    Task<int?> GetProjectIdAsync(int id, CancellationToken cancellationToken);
  }
}