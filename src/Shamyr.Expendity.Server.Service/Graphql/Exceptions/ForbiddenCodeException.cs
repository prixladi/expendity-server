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
      : base($"Curently logge user doesn't have access to '{entityName}' with ID '{id}' for current operation." +
          $"Required permission is '{requiredPermission}'.")
    {
      Code = Constants.ErrorCodes._Forbidden;
    }
  }
}
