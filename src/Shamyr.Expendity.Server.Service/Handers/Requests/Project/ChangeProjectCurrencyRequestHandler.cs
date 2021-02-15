using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Project;
using Shamyr.Expendity.Server.Service.Services;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Project
{
  public class ChangeProjectCurrencyRequestHandler: IRequestHandler<ChangeProjectCurrencyRequest, ProjectCurrencyChangedModel>
  {
    private readonly IDbTransactionService fDbTransactionService;
    private readonly IProjectRepository fProjectRepository;
    private readonly IExpenseRepository fExpenseRepository;

    public ChangeProjectCurrencyRequestHandler(
      IDbTransactionService dbTransactionService,
      IProjectRepository projectRepository,
      IExpenseRepository expenseRepository)
    {
      fDbTransactionService = dbTransactionService;
      fProjectRepository = projectRepository;
      fExpenseRepository = expenseRepository;
    }

    public async Task<ProjectCurrencyChangedModel> Handle(ChangeProjectCurrencyRequest request, CancellationToken cancellationToken)
    {
      return await fDbTransactionService.InTransactionAsync(async () =>
      {
        var oldCurrency = await fProjectRepository.ChangeCurrencyAsync(request.Model.ProjectId, request.Model.NewCurrencyType, cancellationToken);
        long updatedCount = 0;
        if (request.Model.Rate != 1)
          updatedCount = await fExpenseRepository.ChangeCurrencyAsync(request.Model.ProjectId, request.Model.Rate, cancellationToken);

        return new ProjectCurrencyChangedModel
        {
          OldCurrencyType = oldCurrency,
          NewCurrencyType = request.Model.NewCurrencyType,
          ExpensesChangedCount = updatedCount
        };
      }, cancellationToken);
    }
  }
}
