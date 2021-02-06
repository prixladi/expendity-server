using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.Summary;
using Shamyr.Expendity.Server.Service.Models.Summary;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Query
{
  public class SummaryRequestHandler: IRequestHandler<SummaryRequest, SummaryModel>
  {
    private readonly ISummaryRepository fSummaryRepository;
    private readonly IMapper fMapper;

    public SummaryRequestHandler(ISummaryRepository summaryRepository,IMapper mapper)
    {
      fSummaryRepository = summaryRepository;
      fMapper = mapper;
    }

    public async Task<SummaryModel> Handle(SummaryRequest request, CancellationToken cancellationToken)
    {
      var filter = fMapper.Map<SummaryFilterModel, SummaryFilterDto>(request.Model);
      var dto = await fSummaryRepository.GetAsync(filter, cancellationToken);
      return fMapper.Map<SummaryDto, SummaryModel>(dto);
    }
  }
}
