using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("Expenses")]
  [Index(nameof(DateAdded))]
  public class ExpenseEntity: EntityBase
  {
    [Required]
    [StringLength(ValidationConstants._MaxNameLength, MinimumLength = 1)]
    public string Name { get; init; } = default!;

    [Required]
    public decimal Value { get; init; }

    [StringLength(ValidationConstants._MaxDescriptionLength, MinimumLength = 1)]
    public string? Description { get; init; }

    [Required]
    public DateTime DateAdded { get; init; }

    public int? TypeId { get; init; }

    [Required]
    public int ProjectId { get; init; }

    [Required]
    public int CreatorUserId { get; init; }

    public int? LastUpdaterUserId { get; init; }

    [ForeignKey(nameof(TypeId))]
    [InverseProperty(nameof(ExpenseTypeEntity.Expenses))]
    public ExpenseTypeEntity? Type { get; init; }

    [ForeignKey(nameof(ProjectId))]
    public ProjectEntity Project { get; init; } = default!;

    [ForeignKey(nameof(CreatorUserId))]
    public UserEntity CreatorUser { get; init; } = default!;

    [ForeignKey(nameof(LastUpdaterUserId))]
    public UserEntity? LastUpdaterUser { get; init; }
  }
}
