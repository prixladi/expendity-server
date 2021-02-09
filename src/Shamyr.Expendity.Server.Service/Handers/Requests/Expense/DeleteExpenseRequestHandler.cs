using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.Expense;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Expense
{
  public class DeleteExpenseRequestHandler: IRequestHandler<DeleteExpenseRequest, ExpenseModel>
  {
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IMapper fMapper;

    public DeleteExpenseRequestHandler(IExpenseRepository expenseRepository, IMapper mapper)
    {
      fExpenseRepository = expenseRepository;
      fMapper = mapper;
    }

    public async Task<ExpenseModel> Handle(DeleteExpenseRequest request, CancellationToken cancellationToken)
    {
      var dto = await fExpenseRepository.DeleteAsync(request.Id, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Expense");

      return fMapper.Map<ExpenseDto, ExpenseModel>(dto);
    }
  }
}
