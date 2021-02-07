using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Project
{
  public class CreateProjectRequestHandler: IdentityRequestHandlerBase, IRequestHandler<CreateProjectRequest, ProjectModel>
  {
    private readonly IProjectRepository fProjectRepository;
    private readonly IMapper fMapper;

    public CreateProjectRequestHandler(
      IProjectRepository projectRepository, 
      IClaimsIdentityService claimsIdentityService,
      IMapper mapper)
      :base(claimsIdentityService)
    {
      fProjectRepository = projectRepository;
      fMapper = mapper;
    }

    public async Task<ProjectModel> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
    {
      var project = fMapper.Map<NewProjectModel, NewProjectDto>(request.Model);

      var dto = await fProjectRepository.CreateAsync(project, GetIdentity().Id, cancellationToken);
      return fMapper.Map<ProjectDto, ProjectModel>(dto);
    }
  }
}
