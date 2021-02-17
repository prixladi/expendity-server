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
  public class DeleteProjectInviteRequestHandler: IRequestHandler<DeleteProjectInviteRequest, ProjectInviteModel>
  {
    private readonly IProjectInviteRepository fProjectInviteRepository;
    private readonly IMapper fMapper;

    public DeleteProjectInviteRequestHandler(IProjectInviteRepository projectInviteRepository, IMapper mapper)
    {
      fProjectInviteRepository = projectInviteRepository;
      fMapper = mapper;
    }

    public async Task<ProjectInviteModel> Handle(DeleteProjectInviteRequest request, CancellationToken cancellationToken)
    {
      var dto = await fProjectInviteRepository.DeleteAsync(request.Id, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Project Invite");

      return fMapper.Map<ProjectInviteDto, ProjectInviteModel>(dto);
    }
  }
}
