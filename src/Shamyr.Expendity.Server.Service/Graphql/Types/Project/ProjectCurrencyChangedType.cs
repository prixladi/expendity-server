using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Project;

namespace Shamyr.Expendity.Server.Service.Graphql.Types.Project
{
  public class ProjectCurrencyChangedType: ObjectGraphType<ProjectCurrencyChangedModel>
  {
    public ProjectCurrencyChangedType()
    {
      Field(x => x.ExpensesChangedCount);
      Field<NonNullGraphType<CurrencyTypeType>>(nameof(ProjectCurrencyChangedModel.NewCurrencyType));
      Field<NonNullGraphType<CurrencyTypeType>>(nameof(ProjectCurrencyChangedModel.OldCurrencyType));
    }
  }
}
