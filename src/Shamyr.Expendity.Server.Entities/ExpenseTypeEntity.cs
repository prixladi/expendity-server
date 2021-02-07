using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("ExpenseTypes")]
  public class ExpenseTypeEntity: EntityBase
  {
    [Required]
    [StringLength(ValidationConstants._MaxNameLength, MinimumLength = 1)]
    public string Name { get; init; } = default!;

    [StringLength(ValidationConstants._MaxDescriptionLength, MinimumLength = 1)]
    public string? Description { get; init; }

    [Required]
    public int ProjectId {get;init;}

    [ForeignKey(nameof(ProjectId))]
    public ProjectEntity Project { get; init; } = default!;

    [InverseProperty(nameof(ExpenseEntity.Type))]
    public List<ExpenseEntity> Expenses { get; init; } = default!; 
  }
}
