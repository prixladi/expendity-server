﻿using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.ProjectInvite
{
  public class ProjectInvitePreviewModel
  {
    public int Id { get; init; }
    public int ProjectId { get; init; }
    public string ProjectName { get; init; } = default!;
    public string? ProjectDescription { get; init; }
    public PermissionType ProjectPermissionType { get; init; }
  }
}
