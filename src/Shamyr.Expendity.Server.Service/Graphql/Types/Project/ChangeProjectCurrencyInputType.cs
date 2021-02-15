using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ChangeProjectCurrencyInputType: InputObjectGraphType<ChangeProjectCurrencyModel>
  {
    public ChangeProjectCurrencyInputType()
    {
      Field(x => x.ProjectId);
      Field(x => x.Rate);
      Field<NonNullGraphType<CurrencyTypeType>>(nameof(ChangeProjectCurrencyModel.NewCurrencyType));
    }
  }
}
