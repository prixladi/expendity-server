using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;

namespace Shamyr.Expendity.Server.Service.ModelValidation
{
  public class ModelValidationPipeline<TRequest>: IRequestPreProcessor<TRequest>
    where TRequest : notnull
  {
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
      if (request is not IValidable validable)
        return;

      var result = await validable.ValidateAsync(cancellationToken);
      if (result.IsValid)
        return;

      var errors = result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);
      throw new BadRequestCodeException("Validation error.", errors);
    }
  }
}
