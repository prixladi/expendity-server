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

    [InverseProperty(nameof(ExpenseEntity.Type))]
    public ICollection<ExpenseEntity> Expenses { get; init; } = default!; 
  }
}
