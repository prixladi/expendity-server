using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Shamyr.Expendity.Server.Service.ModelValidation
{
  public abstract class Validable<TModel, TValidator>: IValidable<TModel, TValidator>
    where TModel : notnull
    where TValidator : AbstractValidator<TModel>, new()
  {
    public abstract TModel Model { get; }

    public object GetModel()
    {
      return Model;
    }

    public async Task<ValidationResult> ValidateAsync(CancellationToken cancellationToken)
    {
      var validator = (AbstractValidator<TModel>)Activator.CreateInstance(typeof(TValidator))!;
      return await validator.ValidateAsync(Model, cancellationToken);
    }
  }
}
