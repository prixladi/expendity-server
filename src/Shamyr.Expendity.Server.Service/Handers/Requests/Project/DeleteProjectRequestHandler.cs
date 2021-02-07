using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Expendity.Server.Service.Dtos.Project;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.Project;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.Project;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.Project
{
  public class DeleteProjectRequestHandler: IRequestHandler<DeleteProjectRequest, ProjectModel>
  {
    private readonly IProjectRepository fProjectRepository;
    private readonly IMapper fMapper;

    public DeleteProjectRequestHandler(IProjectRepository projectRepository, IMapper mapper)
    {
      fProjectRepository = projectRepository;
      fMapper = mapper;
    }

    public async Task<ProjectModel> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
    {
      var dto = await fProjectRepository.SetDeletedAsync(request.Id, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Project");

      return fMapper.Map<ProjectDto, ProjectModel>(dto);
    }
  }
}
