using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.Summary
{
  public class SummaryFilterModelValidator: AbstractValidator<SummaryFilterModel>
  {
    public SummaryFilterModelValidator()
    {
      RuleFor(x => x.Top)
        .GreaterThan(0);
    }
  }
}
