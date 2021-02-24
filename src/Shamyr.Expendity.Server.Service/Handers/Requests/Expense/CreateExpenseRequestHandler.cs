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
  public class CreateExpenseRequestHandler: IdentityRequestHandlerBase, IRequestHandler<CreateExpenseRequest, ExpenseModel>
  {
    private readonly IExpenseTypeRepository fExpenseTypeRepository;
    private readonly IExpenseRepository fExpenseRepository;
    private readonly IMapper fMapper;

    public CreateExpenseRequestHandler(
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

    public async Task<ExpenseModel> Handle(CreateExpenseRequest request, CancellationToken cancellationToken)
    {
      if (request.Model.TypeId is not null)
      {
        var projectId = await fExpenseTypeRepository.GetProjectIdAsync(request.Model.TypeId.Value, cancellationToken);
        if (projectId == null || projectId.Value != request.Model.ProjectId)
          throw new BadRequestCodeException($"Expense type with ID '{request.Model.TypeId}' does not exist or does not belong to project '{request.Model.ProjectId}'.");
      }

      var dto = fMapper.Map<CreateExpenseModel, CreateExpenseDto>(request.Model,
        opt => opt.AfterMap((_, dto) => dto.CreatorUserId = GetIdentity().Id));

      var detail = await fExpenseRepository.CreateAsync(dto, cancellationToken);

      return fMapper.Map<ExpenseDto, ExpenseModel>(detail, 
        opt => opt.AfterMap((_, dto) => dto.CreatorUserEmail = GetIdentity().Email));
    }
  }
}
