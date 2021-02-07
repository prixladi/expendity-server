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
  public class CreateExpenseRequestHandler: IRequestHandler<CreateExpenseRequest, ExpenseModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IMapper fMapper;

    public CreateExpenseRequestHandler(IExpenseTypeRepository expenseTypeRepository, IExpenseRepository expenseRepository, IMapper mapper)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fExpenseRepository = expenseRepository;
      fMapper = mapper;
    }

    public async Task<ExpenseModel> Handle(CreateExpenseRequest request, CancellationToken cancellationToken)
    {
      if(
        request.Model.TypeId is not null &&
        !await fExpenseTypeRepository.ExistsAsync(request.Model.TypeId.Value, cancellationToken))
      {
        throw new BadRequestCodeException($"Expense type with ID '{request.Model.TypeId}' does not exist.");
      }

      var dto = fMapper.Map<NewExpenseDto>(request.Model);
      var detail = await fExpenseRepository.CreateAsync(dto, cancellationToken);

      return fMapper.Map<ExpenseModel>(detail);
    }
  }
}
