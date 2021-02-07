using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Dtos.Users;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public class UserRepository: RepositoryBase<UserEntity>, IUserRepository
  {
    public UserRepository(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }

    public async Task<UserDto> GetOrCreateAsync(UserProfileDto dto, CancellationToken cancellationToken)
    {
      var user = await DbSet
        .Where(e => e.SubjectId == dto.SubjectId)
        .SingleOrDefaultAsync(cancellationToken);

      if (user is null)
      {
        user = fMapper.Map<UserProfileDto, UserEntity>(dto);
        DbSet.Add(user);
        await fContext.SaveChangesAsync(cancellationToken);
      }

      return fMapper.Map<UserEntity, UserDto>(user);
    }
  }
}
