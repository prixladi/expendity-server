using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ExpenseType
{
  public class CreateExpenseTypeRequestHandler: IRequestHandler<CreateExpenseTypeRequest, ExpenseTypeModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IMapper fMapper;

    public CreateExpenseTypeRequestHandler(IExpenseTypeRepository expenseTypeRepository, IMapper mapper)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fMapper = mapper;
    }

    public async Task<ExpenseTypeModel> Handle(CreateExpenseTypeRequest request, CancellationToken cancellationToken)
    {
      var dto = fMapper.Map<CreateExpenseTypeDto>(request.Model);
      var detail = await fExpenseTypeRepository.CreateAsync(dto, cancellationToken);

      return fMapper.Map<ExpenseTypeModel>(detail);
    }
  }
}
