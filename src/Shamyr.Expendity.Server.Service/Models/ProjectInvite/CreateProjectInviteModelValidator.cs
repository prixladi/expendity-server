using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.ProjectInvite
{
  public class CreateProjectInviteModelValidator: AbstractValidator<CreateProjectInviteModel>
  {
    public CreateProjectInviteModelValidator()
    {
      RuleFor(x => x.ProjectPermissionType)
        .IsInEnum();
    }
  }
}
