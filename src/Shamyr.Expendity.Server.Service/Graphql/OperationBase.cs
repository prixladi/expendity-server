using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public abstract class OperationBase<TSourceType, TReturnType>
  {
    internal abstract string Name { get; }
    internal virtual string? Description { get; } = null;
    internal virtual QueryArguments? Arguments { get; } = null;

    internal abstract Task<TReturnType> ResolveAsync(IResolveFieldContext<TSourceType> context);
  }
}
