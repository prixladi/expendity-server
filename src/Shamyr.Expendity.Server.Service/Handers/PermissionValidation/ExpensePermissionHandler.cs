using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Repositories;

namespace Shamyr.Expendity.Server.Service.Handers.PermissionValidation
{
  public class ExpensePermissionHandler: PermissionValidationHandlerBase<IExpensePermission>
  {
    private readonly IClaimsIdentityService fClaimsIdentityService;
    private readonly IPermissionRepository fPermissionRepository;

    public ExpensePermissionHandler(IClaimsIdentityService claimsIdentityService, IPermissionRepository permissionRepository)
    {
      fClaimsIdentityService = claimsIdentityService;
      fPermissionRepository = permissionRepository;
    }

    protected override async Task DoHandleAsync(IExpensePermission request, CancellationToken cancellationToken)
    {
      // Should only override control for PermissionType.Configure and PermissionType.Own 
      Debug.Assert(!request.OverrideControlForCreator || request.RequiredPermission > PermissionType.Control);
      var identity = fClaimsIdentityService.GetCurrentUser<UserIdentity>();

      var permissionType = await fPermissionRepository.GetForExpenseAsync(request.ExpenseId, identity.Id, cancellationToken);
      if (permissionType == null)
        throw new NotFoundCodeException(request.ExpenseId, "Expense");

      // Uplift control capabilities for creator of the expense
      bool shouldOverrideForControl()
      {
        return permissionType.Type == PermissionType.Control &&
          request.OverrideControlForCreator &&
          permissionType.CreatorUserId == identity.Id;
      }

      if (permissionType.Type < request.RequiredPermission && !shouldOverrideForControl())
        throw new ForbiddenCodeException(request.ExpenseId, "Expense", request.RequiredPermission);
    }
  }
}
