using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ProjectInvite
{
  public class ProjectInviteByTokenRequestHandler: IRequestHandler<ProjectInviteByTokenRequest, ProjectInvitePreviewModel>
  {
    private readonly IProjectPermissionRepository fProjectPermissionRepository;
    private readonly IMapper fMapper;

    public ProjectInviteByTokenRequestHandler(IProjectPermissionRepository projectPermissionRepository, IMapper mapper)
    {
      fProjectPermissionRepository = projectPermissionRepository;
      fMapper = mapper;
    }

    public Task<ProjectInvitePreviewModel> Handle(ProjectInviteByTokenRequest request, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }
  }
}
