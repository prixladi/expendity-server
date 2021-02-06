using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.Summary;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface ISummaryRepository
  {
    Task<SummaryDto> GetAsync(SummaryFilterDto filter, CancellationToken cancellationToken);
  }
}