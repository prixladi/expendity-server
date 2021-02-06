using FluentValidation;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ExpenseType
{
  public class NewExpenseTypeModelValidator: AbstractValidator<NewExpenseTypeModel>
  {
    public NewExpenseTypeModelValidator()
    {
      RuleFor(x => x.Name)
        .NotNull()
        .NotEmpty()
        .MaximumLength(ValidationConstants._MaxNameLength);

      RuleFor(x => x.Description)
        .MaximumLength(ValidationConstants._MaxDescriptionLength);
    }
  }
}
