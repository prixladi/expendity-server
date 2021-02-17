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
  public class ProjectInviteRequestHandler: IRequestHandler<ProjectInviteRequest, ProjectInviteModel>
  {
    private readonly IProjectInviteRepository fProjectInviteRepository;
    private readonly IMapper fMapper;

    public ProjectInviteRequestHandler(IProjectInviteRepository projectInviteRepository, IMapper mapper)
    {
      fProjectInviteRepository = projectInviteRepository;
      fMapper = mapper;
    }

    public async Task<ProjectInviteModel> Handle(ProjectInviteRequest request, CancellationToken cancellationToken)
    {
      var dto = await fProjectInviteRepository.GetAsync(request.Id, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Project Invite");

      return fMapper.Map<ProjectInviteDto, ProjectInviteModel>(dto);
    }
  }
}
