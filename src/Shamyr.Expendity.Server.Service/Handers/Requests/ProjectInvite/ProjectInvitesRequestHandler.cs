using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ProjectInvite
{
  public class ProjectInvitesRequestHandler: IRequestHandler<ProjectInvitesRequest, ProjectInvitesModel>
  {
    private readonly IProjectInviteRepository fProjectInviteRepository;
    private readonly IMapper fMapper;

    public ProjectInvitesRequestHandler(IProjectInviteRepository projectInviteRepository, IMapper mapper)
    {
      fProjectInviteRepository = projectInviteRepository;
      fMapper = mapper;
    }

    public async Task<ProjectInvitesModel> Handle(ProjectInvitesRequest request, CancellationToken cancellationToken)
    {
      var filter = fMapper.Map<ProjectInviteFilterModel, ProjectInviteFilterDto>(request.Model);

      var count = await fProjectInviteRepository.CountAsync(filter, cancellationToken);
      var entries = await fProjectInviteRepository.GetAsync(filter, cancellationToken);

      return new ProjectInvitesModel
      {
        Entries = fMapper.Map<ICollection<ProjectInviteDto>, ProjectInviteModel[]>(entries),
        Count = count
      };
    }
  }
}
