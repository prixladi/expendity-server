using GraphQL.Types;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class ObjectGraphTypeBase<TSourceType>: ObjectGraphType<TSourceType>
  {
    protected FieldType Register<TGraphType, TReturn>(OperationBase<TSourceType, TReturn> field)
      where TGraphType : IGraphType
    {
      return FieldAsync<TGraphType, TReturn>(field.Name, field.Description, field.Arguments, field.ResolveAsync);
    }
  }
}
