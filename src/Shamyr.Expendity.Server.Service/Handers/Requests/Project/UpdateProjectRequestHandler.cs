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
  public class UpdateProjectRequestHandler: IRequestHandler<UpdateProjectRequest, ProjectModel>
  {
    private readonly IProjectRepository fProjectRepository;
    private readonly IMapper fMapper;

    public UpdateProjectRequestHandler(IProjectRepository projectRepository, IMapper mapper)
    {
      fProjectRepository = projectRepository;
      fMapper = mapper;
    }

    public async Task<ProjectModel> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
    {
      var update = fMapper.Map<ProjectUpdateModel, ProjectUpdateDto>(request.Model);

      var dto = await fProjectRepository.UpdateAsync(request.Id, update, cancellationToken);
      if (dto is null)
        throw new NotFoundCodeException(request.Id, "Project");

      return fMapper.Map<ProjectDto, ProjectModel>(dto);
    }
  }
}
