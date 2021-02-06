using System.Collections;
using GraphQL;

namespace Shamyr.Expendity.Server.Service.Graphql.Exceptions
{
  public class BadRequestCodeException: ExecutionError
  {
    public BadRequestCodeException(string message) 
      : base(message)
    {
      Code = Constants.ErrorCodes._BadRequest;
    }

    public BadRequestCodeException(string message, IDictionary data) 
      : base(message, data)
    {
      Code = Constants.ErrorCodes._BadRequest;
    }
  }
}
