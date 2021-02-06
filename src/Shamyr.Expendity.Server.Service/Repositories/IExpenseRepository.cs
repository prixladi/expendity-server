using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.Expense;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IExpenseRepository
  {
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task<ExpenseDto> CreateAsync(NewExpenseDto dto, CancellationToken cancellationToken);
    Task<ICollection<ExpenseDto>> GetAsync(ExpenseFilterDto filter, CancellationToken cancellationToken);
    Task<ExpenseDto> GetAsync(int id, CancellationToken cancellationToken);
  }
}