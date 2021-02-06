using FluentValidation;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class NewExpenseModelValidator: AbstractValidator<NewExpenseModel>
  {
    public NewExpenseModelValidator()
    {
      RuleFor(x => x.Name)
        .NotNull()
        .NotEmpty()
        .MaximumLength(ValidationConstants._MaxNameLength);

      RuleFor(x => x.Value)
        .GreaterThanOrEqualTo(0);

      RuleFor(x => x.Description)
        .MaximumLength(ValidationConstants._MaxDescriptionLength);
    }
  }
}
