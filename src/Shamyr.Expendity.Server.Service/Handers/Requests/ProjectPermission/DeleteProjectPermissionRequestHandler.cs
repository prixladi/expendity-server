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
  public class DeleteProjectPermissionRequestHandler: IRequestHandler<DeleteProjectPermissionRequest, ProjectPermissionModel>
  {
    private readonly IProjectPermissionRepository fProjectPermissionRepository;
    private readonly IMapper fMapper;

    public DeleteProjectPermissionRequestHandler(IProjectPermissionRepository projectPermissionRepository, IMapper mapper)
    {
      fProjectPermissionRepository = projectPermissionRepository;
      fMapper = mapper;
    }

    public async Task<ProjectPermissionModel> Handle(DeleteProjectPermissionRequest request, CancellationToken cancellationToken)
    {
      var dto = await fProjectPermissionRepository.DeleteAsync(request.ProjectId, request.UserId, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException($"ProjectPermission for project '{request.ProjectId}' and user '{request.UserId}' was not found");

      return fMapper.Map<ProjectPermissionDto, ProjectPermissionModel>(dto);
    }
  }
}
