using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class ExpenseFilterModelValidator: AbstractValidator<ExpenseFilterModel>
  {
    public ExpenseFilterModelValidator()
    {
      RuleFor(x => x.Skip)
        .GreaterThanOrEqualTo(0);

      RuleFor(x => x.Count)
        .GreaterThanOrEqualTo(1)
        .LessThanOrEqualTo(200);
    }
  }
}
