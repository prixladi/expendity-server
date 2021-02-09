using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Users;
using Shamyr.Expendity.Server.Service.Models;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class UserMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<UserProfileDto, UserEntity>();
      exp.CreateMap<UserEntity, UserDto>();

      exp.CreateMap<UserIdentity, MeModel>();
    }
  }
}
