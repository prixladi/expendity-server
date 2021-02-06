using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;
using Shamyr.Expendity.Server.Service.Requests.Query;

namespace Shamyr.Expendity.Server.Service.Graphql.Queries
{
  public class Agents: FieldBase<object, ICollection<ExpenseTypeModel>>
  {
    internal override string Name => "expenseTypes";

    private readonly IServiceProvider fServiceProvider;

    public Agents(IServiceProvider serviceProvider)
    {
      fServiceProvider = serviceProvider;
    }

    internal override async Task<ICollection<ExpenseTypeModel>> ResolveAsync(IResolveFieldContext<object> context)
    {
      using var scope = new Scope(fServiceProvider);
      return await scope.Sender.Send(new ExpenseTypesRequest(), context.CancellationToken);
    }
  }
}
