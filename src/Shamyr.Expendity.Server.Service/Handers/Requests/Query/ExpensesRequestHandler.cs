using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.Expense;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Query
{
  public class ExpensesRequestHandler: IRequestHandler<ExpensesRequest, ICollection<ExpenseModel>>
  {
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IMapper fMapper;

    public ExpensesRequestHandler(IExpenseRepository expenseRepository, IMapper mapper)
    {
      fExpenseRepository = expenseRepository;
      fMapper = mapper;
    }

    public async Task<ICollection<ExpenseModel>> Handle(ExpensesRequest request, CancellationToken cancellationToken)
    {
      var filter = fMapper.Map<ExpenseFilterModel, ExpenseFilterDto>(request.Model);

      var dtos = await fExpenseRepository.GetAsync(filter, cancellationToken);
      return fMapper.Map<ICollection<ExpenseDto>, ExpenseModel[]>(dtos);
    }
  }
}
