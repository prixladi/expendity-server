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
using Shamyr.Expendity.Server.Service.Services;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Expense
{
  public class UpdateExpenseRequestHandler: IdentityRequestHandlerBase, IRequestHandler<UpdateExpenseRequest, ExpenseModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IDbTransactionService fDbTransactionService;
    private readonly IMapper fMapper;

    public UpdateExpenseRequestHandler(
      IClaimsIdentityService claimsIdentityService,
      IExpenseTypeRepository expenseTypeRepository,
      IExpenseRepository expenseRepository,
      IDbTransactionService dbTransactionService,
      IMapper mapper)
      : base(claimsIdentityService)
    {
      fExpenseTypeRepository = expenseTypeRepository;
      fExpenseRepository = expenseRepository;
      fDbTransactionService = dbTransactionService;
      fMapper = mapper;
    }

    public async Task<ExpenseModel> Handle(UpdateExpenseRequest request, CancellationToken cancellationToken)
    {
      int? typeProjectId = null;
      if (request.Model.TypeId is not null)
      {
        typeProjectId = await fExpenseTypeRepository.GetProjectIdAsync(request.Model.TypeId.Value, cancellationToken);
        if (typeProjectId == null)
          throw new BadRequestCodeException($"Expense type with ID '{request.Model.TypeId}' does not exist.");
      }

      return await fDbTransactionService.InTransactionAsync(async () =>
      {
        var update = fMapper.Map<UpdateExpenseModel, UpdateExpenseDto>(request.Model,
          opt => opt.AfterMap((_, dto) => dto.LastUpdaterUserId = GetIdentity().Id));

        var dto = await fExpenseRepository.UpdateAsync(request.Id, update, cancellationToken);
        if (dto is null)
          throw new NotFoundCodeException(request.Id, "Expense");

        if (typeProjectId != null && dto.ProjectId != typeProjectId)
          throw new BadRequestCodeException($"Expense type with ID '{request.Model.TypeId}' does not belong to project '{dto.ProjectId}'.");

        return fMapper.Map<ExpenseDto, ExpenseModel>(dto,
          opt => opt.AfterMap((_, model) => model.LastUpdaterUserEmail = GetIdentity().Email));

      }, cancellationToken);
    }
  }
}
