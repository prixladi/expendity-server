using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("Projects")]
  public class ProjectEntity: EntityBase
  {
    [Required]
    [StringLength(ValidationConstants._MaxNameLength, MinimumLength = 1)]
    public string Name { get; init; } = default!;

    [StringLength(ValidationConstants._MaxDescriptionLength, MinimumLength = 1)]
    public string? Description { get; init; }

    [Required]
    public CurrencyType CurrencyType { get; set; }

    [Required]
    public bool Deleted { get; set; }

    [InverseProperty(nameof(ProjectPermissionEntity.Project))]
    public List<ProjectPermissionEntity> Permissions { get; init; } = new List<ProjectPermissionEntity>(1);

    [InverseProperty(nameof(ExpenseTypeEntity.Project))]
    public ICollection<ExpenseTypeEntity> ExpenseTypes { get; init; } = Array.Empty<ExpenseTypeEntity>();
  }
}
