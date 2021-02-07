using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class ProjectMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<NewProjectModel, NewProjectDto>();
      exp.CreateMap<NewProjectDto, ProjectEntity>();

      exp.CreateMap<ProjectUpdateModel, ProjectUpdateDto>();
      exp.CreateMap<ProjectUpdateDto, ProjectEntity>();

      exp.CreateMap<ProjectDto, ProjectModel>();
      exp.CreateMap<ProjectDetailDto, ProjectDetailModel>();

      exp.CreateMap<ProjectFilterModel, ProjectFilterDto>();
    }
  }
}
