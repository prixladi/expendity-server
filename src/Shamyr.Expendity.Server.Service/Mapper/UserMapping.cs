using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Users;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class UserMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<UserProfileDto, UserEntity>();
      exp.CreateMap<UserEntity, UserDto>();
    }
  }
}
