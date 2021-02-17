using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class ProjectInvite: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<CreateProjectInviteModel, CreateProjectInviteDto>();
      exp.CreateMap<CreateProjectInviteDto, ProjectInviteEntity>();

      exp.CreateMap<ProjectInviteEntity, ProjectInviteDto>();
      exp.CreateMap<ProjectInviteDto, ProjectInviteModel>();

      exp.CreateMap<ProjectInvitesDto, ProjectInvitesModel>();
      exp.CreateMap<ProjectInviteFilterModel, ProjectInviteFilterDto>();

      exp.CreateMap<ProjectInviteEntity, ProjectInvitePreviewDto>()
        .ForMember(d => d.ProjectName, me => me.MapFrom(e => e.Project.Name))
        .ForMember(d => d.ProjectDescription, me => me.MapFrom(e => e.Project.Description));

      exp.CreateMap<ProjectInvitePreviewDto, ProjectInvitePreviewModel>();
    }
  }
}
