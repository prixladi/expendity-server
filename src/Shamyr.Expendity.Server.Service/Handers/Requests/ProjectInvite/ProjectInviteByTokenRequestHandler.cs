using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.ProjectInvite;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ProjectInvite
{
  public class ProjectInviteByTokenRequestHandler: IRequestHandler<ProjectInviteByTokenRequest, ProjectInvitePreviewModel>
  {
    private readonly IProjectInviteRepository fProjectInviteRepository;
    private readonly IMapper fMapper;

    public ProjectInviteByTokenRequestHandler(IProjectInviteRepository projectInviteRepository, IMapper mapper)
    {
      fProjectInviteRepository = projectInviteRepository;
      fMapper = mapper;
    }

    public async Task<ProjectInvitePreviewModel> Handle(ProjectInviteByTokenRequest request, CancellationToken cancellationToken)
    {
      var dto = await fProjectInviteRepository.GetPreviewByTokenAsync(request.Token, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException($"Project Invite with Token '{request.Token}' was not found.");

      return fMapper.Map<ProjectInvitePreviewDto, ProjectInvitePreviewModel>(dto);
    }
  }
}
