using GraphQL;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Graphql.Exceptions
{
  public class ForbiddenCodeException: ExecutionError
  {
    public ForbiddenCodeException(string message)
      : base(message)
    {
      Code = Constants.ErrorCodes._Forbidden;
    }

    public ForbiddenCodeException(int id, string entityName, PermissionType requiredPermission)
      : base($"Curently logged user doesn't have access to '{entityName}' with ID '{id}' for current operation." +
          $"Required permission is '{requiredPermission}'.")
    {
      Code = Constants.ErrorCodes._Forbidden;
    }

    public ForbiddenCodeException(int id, string entityName, string? message)
      : base($"Curently logged user doesn't have access to '{entityName}' with ID '{id}' for current operation. {message}")
    {
      Code = Constants.ErrorCodes._Forbidden;
    }

    public ForbiddenCodeException(string message, System.Collections.IDictionary data)
      : base(message, data)
    {
      Code = Constants.ErrorCodes._Forbidden;
    }

    public ForbiddenCodeException(string message, System.Exception exception)
      : base(message, exception)
    {
      Code = Constants.ErrorCodes._Forbidden;
    }
  }
}
