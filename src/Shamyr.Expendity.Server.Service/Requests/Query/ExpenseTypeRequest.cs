using MediatR;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Requests.Query
{
  public class ExpenseTypeRequest: IRequest<ExpenseTypeModel>
  {
    public int Id { get; }

    public ExpenseTypeRequest(int id)
    {
      Id = id;
    }
  }
}
