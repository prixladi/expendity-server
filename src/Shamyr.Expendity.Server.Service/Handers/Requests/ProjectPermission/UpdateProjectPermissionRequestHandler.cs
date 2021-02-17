using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ProjectPermissions;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ProjectPermission
{
  public class UpdateProjectPermissionRequestHandler: IRequestHandler<UpdateProjectPermissionRequest, ProjectPermissionModel>
  {
    private readonly IProjectPermissionRepository fProjectPermissionRepository;
    private readonly IMapper fMapper;

    public UpdateProjectPermissionRequestHandler(IProjectPermissionRepository projectPermissionRepository, IMapper mapper)
    {
      fProjectPermissionRepository = projectPermissionRepository;
      fMapper = mapper;
    }

    public async Task<ProjectPermissionModel> Handle(UpdateProjectPermissionRequest request, CancellationToken cancellationToken)
    {
      var update = fMapper.Map<UpdateProjectPermissionModel, UpdateProjectPermissionDto>(request.Model);

      var dto = await fProjectPermissionRepository.UpdateAsync(request.ProjectId, request.UserId, update, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException($"ProjectPermission for project '{request.ProjectId}' and user '{request.UserId}' was not found.");

      return fMapper.Map<ProjectPermissionDto, ProjectPermissionModel>(dto);
    }
  }
}
