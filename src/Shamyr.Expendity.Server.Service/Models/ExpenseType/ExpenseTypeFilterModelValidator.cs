using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.ExpenseType
{
  public class ExpenseTypeFilterModelValidator: AbstractValidator<ExpenseTypeFilterModel>
  {
    public ExpenseTypeFilterModelValidator()
    {
      RuleFor(x => x.Skip)
        .GreaterThanOrEqualTo(0);

      RuleFor(x => x.Count)
        .GreaterThanOrEqualTo(1)
        .LessThanOrEqualTo(200);
    }
  }
}
