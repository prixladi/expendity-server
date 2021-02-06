using System;
using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Graphql.Mutations;
using Shamyr.Expendity.Server.Service.Graphql.Types;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class Mutation: ObjectGraphTypeBase<object>, IMutation
  {
    private readonly IServiceProvider fServiceProvider;

    public Mutation(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;

      Name = "Mutation";

      Register<NonNullGraphType<ExpenseType>, ExpenseModel>(new CreateExpense(fServiceProvider));
      Register<NonNullGraphType<ExpenseTypeType>, ExpenseTypeModel>(new CreateExpenseType(fServiceProvider));
    }
  }
}
