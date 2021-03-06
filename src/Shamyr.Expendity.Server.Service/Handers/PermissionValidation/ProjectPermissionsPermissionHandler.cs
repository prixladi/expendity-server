﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.PermissionValidation;
using Shamyr.Expendity.Server.Service.Repositories;

namespace Shamyr.Expendity.Server.Service.Handers.PermissionValidation
{
  public class ProjectPermissionsPermissionHandler: PermissionValidationHandlerBase<IProjectPermissionsPermission>
  {
    private readonly IClaimsIdentityService fClaimsIdentityService;
    private readonly IPermissionRepository fPermissionRepository;

    public ProjectPermissionsPermissionHandler(IClaimsIdentityService claimsIdentityService, IPermissionRepository permissionRepository)
    {
      fClaimsIdentityService = claimsIdentityService;
      fPermissionRepository = permissionRepository;
    }

    protected override async Task DoHandleAsync(IProjectPermissionsPermission request, CancellationToken cancellationToken)
    {
      var identity = fClaimsIdentityService.GetCurrentUser<UserIdentity>();
      if (request.UserId == identity.Id)
        throw new BadRequestException("Users can't change their own permissions.");

      var permissions = await fPermissionRepository.GetForPermissionAsync(request.ProjectId, request.UserId, identity.Id, cancellationToken);
      // Either current user or manipulated user doesn't have permissions for current project or project doesn't exist
      if (permissions.Length < 2)
        throw new NotFoundCodeException(request.ProjectId, "Project");

      var currentUser = permissions.Single(x => x.UserId == identity.Id);
      var manipulatedUser = permissions.Single(x => x.UserId == request.UserId);

      if (currentUser.PermissionType < request.RequiredPermission)
        throw new ForbiddenCodeException(request.ProjectId, "Project", request.RequiredPermission);

      if (currentUser.PermissionType < manipulatedUser.PermissionType)
        throw new ForbiddenCodeException(request.ProjectId, "Project", $"User with id '{request.UserId}' has higher permission than current user.");

    }
  }
}
