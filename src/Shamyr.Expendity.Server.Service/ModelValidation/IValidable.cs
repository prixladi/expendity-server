using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Shamyr.Expendity.Server.Service.ModelValidation
{
  public interface IValidable<TModel, TValidator>: IValidable
    where TModel : notnull
    where TValidator : AbstractValidator<TModel>, new()
  {
    TModel Model { get; }
  }

  public interface IValidable
  {
    Task<ValidationResult> ValidateAsync(CancellationToken cancellationToken);
  }
}
