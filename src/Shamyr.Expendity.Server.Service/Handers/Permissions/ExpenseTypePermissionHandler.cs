using System.Threading;
using System.Threading.Tasks;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Permissions;
using Shamyr.Expendity.Server.Service.Repositories;

namespace Shamyr.Expendity.Server.Service.Handers.Permissions
{
  public class ExpenseTypePermissionHandler: PermissionHandlerBase<IExpenseTypePermission>
  {
    private readonly IClaimsIdentityService fClaimsIdentityService;
    private readonly IPermissionRepository fPermissionRepository;

    public ExpenseTypePermissionHandler(IClaimsIdentityService claimsIdentityService, IPermissionRepository permissionRepository)
    {
      fClaimsIdentityService = claimsIdentityService;
      fPermissionRepository = permissionRepository;
    }

    protected override async Task DoHandleAsync(IExpenseTypePermission request, CancellationToken cancellationToken)
    {
      var identity = fClaimsIdentityService.GetCurrentUser<UserIdentity>();

      var permissionType = await fPermissionRepository.GetForExpenseTypeAsync(request.ExpenseTypeId, identity.Id, cancellationToken);
      if (permissionType == null)
        throw new NotFoundCodeException(request.ExpenseTypeId, "Expense Type");

      if (permissionType.Value < request.RequiredPermission)
        throw new ForbiddenCodeException(request.ExpenseTypeId, "Expense Type", request.RequiredPermission);
    }
  }
}
