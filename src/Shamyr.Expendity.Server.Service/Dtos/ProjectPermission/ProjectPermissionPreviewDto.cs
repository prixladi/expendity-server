﻿using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectPermission
{
  public class ProjectPermissionPreviewDto
  {
    public int Id { get; init; }
    public PermissionType Type { get; init; }
    public int UserId { get; init; }
  }
}
