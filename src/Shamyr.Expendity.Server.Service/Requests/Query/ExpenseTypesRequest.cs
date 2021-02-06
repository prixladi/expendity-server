using System.Collections.Generic;
using MediatR;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Requests.Query
{
  public class ExpenseTypesRequest: IRequest<ICollection<ExpenseTypeModel>>
  {
  }
}
