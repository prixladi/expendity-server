using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("ProjectPermissions")]
  [Index(nameof(UserId), nameof(ProjectId), IsUnique = true)]
  [Index(nameof(UserId))]
  public class ProjectPermissionEntity: EntityBase
  {
    [Required]
    public int UserId { get; init; }

    [Required]
    public int ProjectId { get; init; }

    [Required]
    public PermissionType Type { get; init; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(UserEntity.ProjectPermissions))]
    public UserEntity User { get; init; } = default!;

    [ForeignKey(nameof(ProjectId))]
    [InverseProperty(nameof(ProjectEntity.Permissions))]
    public ProjectEntity Project { get; init; } = default!;
  }
}
