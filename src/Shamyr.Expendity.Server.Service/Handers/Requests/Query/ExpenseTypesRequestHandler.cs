using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Query
{
  public class ExpenseTypesRequestHandler: IRequestHandler<ExpenseTypesRequest, ICollection<ExpenseTypeModel>>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IMapper fMapper;

    public ExpenseTypesRequestHandler(IExpenseTypeRepository expenseTypeRepository, IMapper mapper)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fMapper = mapper;
    }

    public async Task<ICollection<ExpenseTypeModel>> Handle(ExpenseTypesRequest request, CancellationToken cancellationToken)
    {
      var dtos = await fExpenseTypeRepository.GetAsync(cancellationToken);
      return fMapper.Map<ICollection<ExpenseTypeDto>, ExpenseTypeModel[]>(dtos);
    }
  }
}
