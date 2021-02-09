using System.Collections;
using GraphQL;

namespace Shamyr.Expendity.Server.Service.Graphql.Exceptions
{
  public class ConflictCodeException: ExecutionError
  {
    public ConflictCodeException(string message)
      : base(message)
    {
      Code = Constants.ErrorCodes._Conflict;
    }

    public ConflictCodeException(string message, IDictionary data)
      : base(message, data)
    {
      Code = Constants.ErrorCodes._Conflict;
    }

    public ConflictCodeException(string message, System.Exception exception)
      : base(message, exception)
    {
      Code = Constants.ErrorCodes._Conflict;
    }
  }
}
