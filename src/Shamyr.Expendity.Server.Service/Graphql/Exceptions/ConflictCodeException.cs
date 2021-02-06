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
  }
}
