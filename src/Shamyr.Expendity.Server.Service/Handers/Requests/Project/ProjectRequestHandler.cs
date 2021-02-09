using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Project
{
  public class ProjectRequestHandler: IdentityRequestHandlerBase, IRequestHandler<ProjectRequest, ProjectDetailModel>
  {
    private readonly IProjectPermissionRepository fProjectPermissionRepository;
    private readonly IMapper fMapper;

    public ProjectRequestHandler(
      IProjectPermissionRepository projectPermissionRepository,
      IClaimsIdentityService claimsIdentityService,
      IMapper mapper)
      : base(claimsIdentityService)
    {
      fProjectPermissionRepository = projectPermissionRepository;
      fMapper = mapper;
    }

    public async Task<ProjectDetailModel> Handle(ProjectRequest request, CancellationToken cancellationToken)
    {
      var dto = await fProjectPermissionRepository.GetProjectAsync(request.Id, GetIdentity().Id, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Project");

      return fMapper.Map<ProjectDetailDto, ProjectDetailModel>(dto);
    }
  }
}
