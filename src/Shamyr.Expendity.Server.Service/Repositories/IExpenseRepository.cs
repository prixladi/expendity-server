using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.Expense;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IExpenseRepository
  {
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task<ExpenseDto> CreateAsync(CreateExpenseDto dto, CancellationToken cancellationToken);
    Task<ICollection<ExpenseDto>> GetAsync(ExpenseFilterDto filter, CancellationToken cancellationToken);
    Task<long> CountAsync(ExpenseFilterDto filter, CancellationToken cancellationToken);
    Task<ExpenseDto> GetAsync(int id, CancellationToken cancellationToken);
    Task<ExpenseDto?> UpdateAsync(int id, UpdateExpenseDto update, CancellationToken cancellationToken);
    Task<ExpenseDto?> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<long> ChangeCurrencyAsync(int projectId, decimal rate, CancellationToken cancellationToken);
  }
}