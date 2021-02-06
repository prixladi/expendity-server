using FluentValidation;

namespace Shamyr.Expendity.Server.Service.Models
{
  public class PaginationModelValidator: AbstractValidator<PaginationModel>
  {
    public PaginationModelValidator()
    {
      RuleFor(x => x.Skip)
        .GreaterThanOrEqualTo(0);

      RuleFor(x => x.Count)
        .GreaterThanOrEqualTo(1)
        .LessThanOrEqualTo(200);
    }
  }
}
