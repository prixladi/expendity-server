using System.Threading;
using System.Threading.Tasks;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.PermissionValidation;
using Shamyr.Expendity.Server.Service.Repositories;

namespace Shamyr.Expendity.Server.Service.Handers.PermissionValidation
{
  public class ProjectInvitePermissionHandler: PermissionValidationHandlerBase<IProjectInvitePermission>
  {
    private readonly IClaimsIdentityService fClaimsIdentityService;
    private readonly IPermissionRepository fPermissionRepository;

    public ProjectInvitePermissionHandler(IClaimsIdentityService claimsIdentityService, IPermissionRepository permissionRepository)
    {
      fClaimsIdentityService = claimsIdentityService;
      fPermissionRepository = permissionRepository;
    }

    protected override async Task DoHandleAsync(IProjectInvitePermission request, CancellationToken cancellationToken)
    {
      var identity = fClaimsIdentityService.GetCurrentUser<UserIdentity>();

      var permissionType = await fPermissionRepository.GetForProjectInviteAsync(request.ProjectInviteId, identity.Id, cancellationToken);
      if (permissionType == null)
        throw new NotFoundCodeException(request.ProjectInviteId, "Project Invite");

      if (permissionType.Value < request.RequiredPermission)
        throw new ForbiddenCodeException(request.ProjectInviteId, "Project Invite", request.RequiredPermission);
    }
  }
}
