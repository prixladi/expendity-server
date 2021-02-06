using AutoMapper;
using Shamyr.Expendity.Server.Service.Dtos.Summary;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class SummaryMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<SummaryEntryDto, SummaryEntryModel>();
      exp.CreateMap<SummaryDto, SummaryModel>();

      exp.CreateMap<SummaryFilterModel, SummaryFilterDto>();
    }
  }
}
