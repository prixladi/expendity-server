using System;
using System.Collections.Generic;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;

namespace Shamyr.Expendity.Server.Service.Dtos.Project
{
  public class ProjectDetailDto: ProjectDto
  {
    public ICollection<ProjectPermissionDto> Permissions { get; init; } = Array.Empty<ProjectPermissionDto>();
    public ICollection<ExpenseTypeDto> ExpenseTypes { get; init; } = Array.Empty<ExpenseTypeDto>();
  }
}
