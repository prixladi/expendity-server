using MediatR;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectInvite
{
  public class AcceptProjectInviteRequest: IRequest<ProjectPermissionModel>
  {
    public string Token { get; }

    public AcceptProjectInviteRequest(string token)
    {
      Token = token;
    }
  }
}
