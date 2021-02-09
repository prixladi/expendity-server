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
  public class UpdateExpenseTypeRequestHandler: IRequestHandler<UpdateExpenseTypeRequest, ExpenseTypeModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IMapper fMapper;

    public UpdateExpenseTypeRequestHandler(IExpenseTypeRepository expenseTypeRepository, IMapper mapper)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fMapper = mapper;
    }

    public async Task<ExpenseTypeModel> Handle(UpdateExpenseTypeRequest request, CancellationToken cancellationToken)
    {
      var update = fMapper.Map<UpdateExpenseTypeModel, UpdateExpenseTypeDto>(request.Model);

      var dto = await fExpenseTypeRepository.UpdateAsync(request.Id, update, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Expense type");

      return fMapper.Map<ExpenseTypeDto, ExpenseTypeModel>(dto);
    }
  }
}
