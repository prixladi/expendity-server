using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Queries;
using Shamyr.Expendity.Server.Service.Graphql.Types;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExchangeRate;
using Shamyr.Expendity.Server.Service.Graphql.Types.Expense;
using Shamyr.Expendity.Server.Service.Graphql.Types.ExpenseType;
using Shamyr.Expendity.Server.Service.Graphql.Types.Project;
using Shamyr.Expendity.Server.Service.Graphql.Types.ProjectInvite;
using Shamyr.Expendity.Server.Service.Graphql.Types.Summary;
using Shamyr.Expendity.Server.Service.Models;
using Shamyr.Expendity.Server.Service.Models.ExchangeRate;
using Shamyr.Expendity.Server.Service.Models.Expense;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.Summary;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class Query: ObjectGraphTypeBase<object>, IQuery
  {
    public Query()
    {
      Name = "Query";

      RegisterAuthenticated<NonNullGraphType<MeType>, MeModel>(new Me());

      RegisterAuthenticated<NonNullGraphType<ExchangeRatesType>, ExchangeRatesModel>(new ExchangeRates());

      RegisterAuthenticated<NonNullGraphType<ProjectDetailType>, ProjectDetailModel>(new Project());
      RegisterAuthenticated<NonNullGraphType<ProjectsType>, ProjectsModel>(new Projects());

      RegisterAuthenticated<NonNullGraphType<Types.Expense.ExpenseType>, ExpenseModel>(new Expense());
      RegisterAuthenticated<NonNullGraphType<ExpensesType>, ExpensesModel>(new Expenses());

      RegisterAuthenticated<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new Queries.ExpenseType());

      RegisterAuthenticated<NonNullGraphType<SummaryType>, SummaryModel>(new Summary());

      RegisterAuthenticated<NonNullGraphType<ProjectInviteType>, ProjectInviteModel>(new ProjectInvite());
      RegisterAuthenticated<NonNullGraphType<ProjectInvitePreviewType>, ProjectInvitePreviewModel>(new ProjectInviteByToken());
      RegisterAuthenticated<NonNullGraphType<ProjectInvitesType>, ProjectInvitesModel>(new ProjectInvites());
    }
  }
}
