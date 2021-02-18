using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.ProjectInvite;
using Shamyr.Expendity.Server.Service.Models.ProjectInvite;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;
using Shamyr.Security;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ProjectInvite
{
  public class CreateProjectInviteRequestHandler: IRequestHandler<CreateProjectInviteRequest, ProjectInviteModel>
  {
    private readonly IProjectInviteRepository fProjectInviteRepository;
    private readonly IMapper fMapper;

    public CreateProjectInviteRequestHandler(IProjectInviteRepository projectInviteRepository, IMapper mapper)
    {
      fProjectInviteRepository = projectInviteRepository;
      fMapper = mapper;
    }

    public async Task<ProjectInviteModel> Handle(CreateProjectInviteRequest request, CancellationToken cancellationToken)
    {
      var token = SecurityUtils.GetUrlToken(ValidationConstants._InviteTokenMaxLength / 2);
      var projectInvite = fMapper.Map<CreateProjectInviteModel, CreateProjectInviteDto>(request.Model, 
        opt => opt.AfterMap((_, dto) => dto.Token = token));

      var dto = await fProjectInviteRepository.CreateAsync(projectInvite, cancellationToken);
      return fMapper.Map<ProjectInviteDto, ProjectInviteModel>(dto);
    }
  }
}
