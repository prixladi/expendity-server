﻿using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Dtos.ProjectPermission
{
  public class ProjectPermissionDto
  {
    public int Id { get; init; }
    public PermissionType Type { get; init; }
    public int UserId { get; init; }
    public string UserEmail { get; init; } = default!;
    public int ProjectId { get; set; } = default!;
  }
}
