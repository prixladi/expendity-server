﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shamyr.Expendity.Server.Service.Dtos.Project;

namespace Shamyr.Expendity.Server.Service.Repositories
{
  public interface IProjectRepository
  {
    Task<ProjectDto> CreateAsync(NewProjectDto dto, int userId, CancellationToken cancellationToken);
    Task<ProjectDto?> SetDeletedAsync(int id, CancellationToken cancellationToken);
    Task<ProjectDto?> UpdateAsync(int id, ProjectUpdateDto update, CancellationToken cancellationToken);
  }
}