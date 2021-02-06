﻿using GraphQL.Types;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Graphql.Types
{
  public class ExpenseType: ObjectGraphType<ExpenseModel>
  {
    public ExpenseType()
    {
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Value);
      Field(x => x.Description, nullable: true);
      Field(x => x.AddedUtc);
      Field(x => x.TypeId, nullable: true);
    }
  }
}
