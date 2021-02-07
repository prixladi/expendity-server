using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("Users")]
  [Index(nameof(SubjectId), IsUnique = true)]
  public class UserEntity: EntityBase
  {
    [Required]
    public string SubjectId { get; init; } = default!;

    [Required]
    public string Email { get; init; } = default!;

    public string? Username { get; init; }

    public string? GivenName { get; init; }

    public string? FamilyName { get; init; }

    [InverseProperty(nameof(ProjectPermissionEntity.User))]
    public ICollection<ProjectPermissionEntity> ProjectPermissions { get; set; } = Array.Empty<ProjectPermissionEntity>();
  }
}
