using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.ProjectPermission
{
  public class ChangePermissionModelValidator: AbstractValidator<ChangePermissionModel>
  {
    public ChangePermissionModelValidator()
    {
      RuleFor(x => x.PermissionType)
        .IsInEnum();
    }
  }
}
