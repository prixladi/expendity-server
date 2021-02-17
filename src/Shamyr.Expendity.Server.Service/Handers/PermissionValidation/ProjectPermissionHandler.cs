using System.Threading;
using System.Threading.Tasks;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Repositories;

namespace Shamyr.Expendity.Server.Service.Handers.PermissionValidation
{
  public class ProjectPermissionHandler: PermissionValidationHandlerBase<IProjectPermission>
  {
    private readonly IClaimsIdentityService fClaimsIdentityService;
    private readonly IPermissionRepository fPermissionRepository;

    public ProjectPermissionHandler(IClaimsIdentityService claimsIdentityService, IPermissionRepository permissionRepository)
    {
      fClaimsIdentityService = claimsIdentityService;
      fPermissionRepository = permissionRepository;
    }

    protected override async Task DoHandleAsync(IProjectPermission request, CancellationToken cancellationToken)
    {
      var identity = fClaimsIdentityService.GetCurrentUser<UserIdentity>();

      var permissionType = await fPermissionRepository.GetForProjectAsync(request.ProjectId, identity.Id, cancellationToken);
      if (permissionType == null)
        throw new NotFoundCodeException(request.ProjectId, "Project");

      if (permissionType.Value < request.RequiredPermission)
        throw new ForbiddenCodeException(request.ProjectId, "Project", request.RequiredPermission);
    }
  }
}
