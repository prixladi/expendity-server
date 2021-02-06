using GraphQL.Types;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class ObjectGraphTypeBase<TSourceType>: ObjectGraphType<TSourceType>
  {
    protected void Register<TGraphType, TReturn>(FieldBase<TSourceType, TReturn> field)
      where TGraphType : IGraphType
    {
      FieldAsync<TGraphType, TReturn>(field.Name, field.Description, field.Arguments, field.ResolveAsync);
    }
  }
}
