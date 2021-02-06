using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("Expenses")]
  [Index(nameof(AddedUtc))]
  public class ExpenseEntity: EntityBase
  {
    [Required]
    [StringLength(ValidationConstants._MaxNameLength, MinimumLength = 1)]
    public string Name { get; init; } = default!;

    [Required]
    public double Value { get; init; }

    [StringLength(ValidationConstants._MaxDescriptionLength, MinimumLength = 1)]
    public string? Description { get; init; }

    [Required]
    public DateTime AddedUtc { get; init; } = DateTime.UtcNow;

    public int? TypeId { get; init; }

    [ForeignKey(nameof(TypeId))]
    [InverseProperty(nameof(ExpenseTypeEntity.Expenses))]
    public ExpenseTypeEntity? Type { get; init; } = default!;
  }
}
