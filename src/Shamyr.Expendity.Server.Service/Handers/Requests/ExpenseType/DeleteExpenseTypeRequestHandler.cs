using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ExpenseType
{
  public class DeleteExpenseTypeRequestHandler: IRequestHandler<DeleteExpenseTypeRequest, ExpenseTypeModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IMapper fMapper;

    public DeleteExpenseTypeRequestHandler(IExpenseTypeRepository expenseTypeRepository, IMapper mapper)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fMapper = mapper;
    }

    public async Task<ExpenseTypeModel> Handle(DeleteExpenseTypeRequest request, CancellationToken cancellationToken)
    {
      var dto = await fExpenseTypeRepository.DeleteAsync(request.Id, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Expense Type");

      return fMapper.Map<ExpenseTypeDto, ExpenseTypeModel>(dto);
    }
  }
}
