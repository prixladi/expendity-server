using MediatR;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Requests.ProjectInvite
{
  public class ProjectInviteByTokenRequest: IRequest<ProjectInvitePreviewModel>
  {
    public string Token { get; }

    public ProjectInviteByTokenRequest(string token)
    {
      Token = token;
    }
  }
}
