using GraphQL;

namespace Shamyr.Expendity.Server.Service.Graphql.Exceptions
{
  public class NotFoundCodeException: ExecutionError
  {
    public NotFoundCodeException(string message)
      : base(message)
    {
      Code = Constants.ErrorCodes._NotFound;
    }

    public NotFoundCodeException(int id, string entityName)
      : base($"{entityName} with ID '{id}' was not found. Or currently logged user doesn't have access to it.")
    {
      Code = Constants.ErrorCodes._NotFound;
    }
  }
}
