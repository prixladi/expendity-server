using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Cloud.Authority.Client.Factories;
using Shamyr.Cloud.Authority.Models;
using Shamyr.Expendity.Server.Service.Dtos.Users;
using Shamyr.Expendity.Server.Service.Repositories;

namespace Shamyr.Expendity.Server.Service.Factories
{
  public class PrincipalFactory: PrincipalFactoryBase
  {
    private readonly IUserRepository fUserRepository;

    public PrincipalFactory(IUserRepository userRepository)
    {
      fUserRepository = userRepository;
    }

    protected override async Task<ClaimsIdentity> CreateIdentityAsync(IServiceProvider serviceProvider, string authenticationType, UserModel model, CancellationToken cancellationToken)
    {
      var user = await fUserRepository.GetOrCreateAsync(new UserProfileDto
      {
        SubjectId = model.Id,
        Email = model.Email,
        Username = model.Username
      }, cancellationToken);

      return new UserIdentity(user.Id, user.SubjectId, user.Email, authenticationType)
      {
        Username = user.Username
      };
    }
  }
}
