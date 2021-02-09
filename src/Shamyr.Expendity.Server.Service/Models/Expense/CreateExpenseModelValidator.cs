using FluentValidation;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Expense
{
  public class CreateExpenseModelValidator: AbstractValidator<CreateExpenseModel>
  {
    public CreateExpenseModelValidator()
    {
      RuleFor(x => x.Name)
        .NotNull()
        .NotEmpty()
        .MaximumLength(ValidationConstants._MaxNameLength);

      RuleFor(x => x.Description)
        .MaximumLength(ValidationConstants._MaxDescriptionLength);

      RuleFor(x => x.Value)
        .GreaterThanOrEqualTo(0);
    }
  }
}
