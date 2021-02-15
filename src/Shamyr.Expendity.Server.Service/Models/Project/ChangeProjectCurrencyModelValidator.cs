using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class ChangeProjectCurrencyModelValidator: AbstractValidator<ChangeProjectCurrencyModel>
  {
    public ChangeProjectCurrencyModelValidator()
    {
      RuleFor(x => x.Rate)
        .GreaterThan(0);

      RuleFor(x => x.NewCurrencyType)
        .IsInEnum();
    }
  }
}
