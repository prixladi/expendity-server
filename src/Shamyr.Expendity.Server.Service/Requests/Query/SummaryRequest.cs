using MediatR;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Requests.Query
{
  public class SummaryRequest: IRequest<SummaryModel>
  {
    public SummaryFilterModel Model { get; }

    public SummaryRequest(SummaryFilterModel model)
    {
      Model = model;
    }
  }
}
