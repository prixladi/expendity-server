using System.Collections.Generic;
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
  public class ProjectsRequestHandler: IdentityRequestHandlerBase, IRequestHandler<ProjectsRequest, ProjectsModel>
  {
    private readonly IProjectPermissionRepository fProjectPermissionRepository;
    private readonly IMapper fMapper;

    public ProjectsRequestHandler(
      IProjectPermissionRepository projectPermissionRepository,
      IClaimsIdentityService claimsIdentityService,
      IMapper mapper)
       : base(claimsIdentityService)
    {
      fProjectPermissionRepository = projectPermissionRepository;
      fMapper = mapper;
    }

    public async Task<ProjectsModel> Handle(ProjectsRequest request, CancellationToken cancellationToken)
    {
      var identity = GetIdentity();
      var filter = fMapper.Map<ProjectFilterModel, ProjectFilterDto>(request.Model);

      var count = await fProjectPermissionRepository.CountProjectsAsync(filter, identity.Id, cancellationToken);
      var entries = await fProjectPermissionRepository.GetProjectsAsync(filter, identity.Id, cancellationToken);

      return new ProjectsModel
      {
        Entries = fMapper.Map<ICollection<ProjectDto>, ProjectModel[]>(entries),
        Count = count
      };
    }
  }
}
