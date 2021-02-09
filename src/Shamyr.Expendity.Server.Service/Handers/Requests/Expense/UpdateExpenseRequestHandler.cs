using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Dtos.Expense;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Expense;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Expense
{
  public class UpdateExpenseRequestHandler: IdentityRequestHandlerBase, IRequestHandler<UpdateExpenseRequest, ExpenseModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IMapper fMapper;

    public UpdateExpenseRequestHandler(
      IClaimsIdentityService claimsIdentityService,
      IExpenseTypeRepository expenseTypeRepository,
      IExpenseRepository expenseRepository,
      IMapper mapper)
      : base(claimsIdentityService)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fExpenseRepository = expenseRepository;
      fMapper = mapper;
    }

    public async Task<ExpenseModel> Handle(UpdateExpenseRequest request, CancellationToken cancellationToken)
    {
      if (
        request.Model.TypeId is not null &&
        !await fExpenseTypeRepository.ExistsAsync(request.Model.TypeId.Value, cancellationToken))
      {
        throw new BadRequestCodeException($"Expense type with ID '{request.Model.TypeId}' does not exist.");
      }

      var update = fMapper.Map<UpdateExpenseModel, UpdateExpenseDto>(request.Model,
        opt => opt.AfterMap((_, dto) => dto.UpdaterUserId = GetIdentity().Id));

      var dto = await fExpenseRepository.UpdateAsync(request.Id, update, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Expense");

      return fMapper.Map<ExpenseDto, ExpenseModel>(dto);
    }
  }
}
