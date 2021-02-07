using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class ProjectPermissionMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<ProjectPermissionEntity, ProjectDto>()
        .ForMember(dto => dto.Id, me => me.MapFrom(e => e.Project.Id))
        .ForMember(dto => dto.Name, me => me.MapFrom(e => e.Project.Name))
        .ForMember(dto => dto.Description, me => me.MapFrom(e => e.Project.Description))
        .ForMember(dto => dto.UserPermission, me => me.MapFrom(e => e.Type));

      exp.CreateMap<ProjectPermissionEntity, ProjectDetailDto>()
        .ForMember(dto => dto.Id, me => me.MapFrom(e => e.Project.Id))
        .ForMember(dto => dto.Name, me => me.MapFrom(e => e.Project.Name))
        .ForMember(dto => dto.Description, me => me.MapFrom(e => e.Project.Description))
        .ForMember(dto => dto.UserPermission, me => me.MapFrom(e => e.Type))
        .ForMember(dto => dto.Permissions, me => me.MapFrom(e => e.Project.Permissions))
        .ForMember(dto => dto.ExpenseTypes, me => me.MapFrom(e => e.Project.ExpenseTypes));

      exp.CreateMap<ProjectPermissionEntity, ProjectPermissionDto>()
        .ForMember(dto => dto.UserEmail, me => me.MapFrom(e => e.User.Email));

      exp.CreateMap<ProjectPermissionDto, ProjectPermissionModel>();
    }
  }
}
