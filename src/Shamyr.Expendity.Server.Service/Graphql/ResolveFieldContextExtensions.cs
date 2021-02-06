using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GraphQL;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public static class ResolveFieldContextExtensions
  {
    public static async Task<TType> GetArgumentAsync<TType, TValidator>(this IResolveFieldContext context, string name, CancellationToken cancellationToken)
      where TValidator : AbstractValidator<TType>, new()
    {
      var argument = context.GetArgument<TType>(name);

      var validator = new TValidator();
      var result = await validator.ValidateAsync(argument, cancellationToken);
      if (result.IsValid)
        return argument;

      var errors = result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);
      throw new BadRequestCodeException("Validation error.", errors);
    }
  }
}
