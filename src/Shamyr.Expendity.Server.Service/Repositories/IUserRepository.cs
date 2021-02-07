using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.Users;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IUserRepository
  {
    Task<UserDto> GetOrCreateAsync(UserProfileDto dto, CancellationToken cancellationToken);
  }
}