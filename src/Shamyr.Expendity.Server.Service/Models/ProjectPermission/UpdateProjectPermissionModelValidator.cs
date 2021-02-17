using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.ProjectPermission
{
  public class UpdateProjectPermissionModelValidator: AbstractValidator<UpdateProjectPermissionModel>
  {
    public UpdateProjectPermissionModelValidator()
    {
      RuleFor(x => x.PermissionType)
        .IsInEnum();
    }
  }
}
