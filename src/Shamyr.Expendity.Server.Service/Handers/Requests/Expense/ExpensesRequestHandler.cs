using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.Expense;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Expense
{
  public class ExpensesRequestHandler: IRequestHandler<ExpensesRequest, ExpensesModel>
  {
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IMapper fMapper;

    public ExpensesRequestHandler(IExpenseRepository expenseRepository, IMapper mapper)
    {
      fExpenseRepository = expenseRepository;
      fMapper = mapper;
    }

    public async Task<ExpensesModel> Handle(ExpensesRequest request, CancellationToken cancellationToken)
    {
      var filter = fMapper.Map<ExpenseFilterModel, ExpenseFilterDto>(request.Model);

      var count = await fExpenseRepository.CountAsync(filter, cancellationToken);
      var dtos = await fExpenseRepository.GetAsync(filter, cancellationToken);

      return new ExpensesModel
      {
        Entries = fMapper.Map<ICollection<ExpenseDto>, ExpenseModel[]>(dtos),
        Count = count,
      };
    }
  }
}
