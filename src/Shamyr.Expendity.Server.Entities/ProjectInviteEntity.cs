using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Entities
{
  [Table("ProjectInvites")]
  [Index(nameof(Token), IsUnique = true)]
  public class ProjectInviteEntity: EntityBase
  {
    [Required]
    public int ProjectId { get; init; }

    [Required]
    [StringLength(ValidationConstants._InviteTokenMaxLength, MinimumLength = 1)]
    public string Token { get; init; } = default!;

    // Permission that will user have after accepting this invite
    [Required]
    public PermissionType ProjectPermissionType { get; init; }

    [Required]
    public bool IsMultiUse { get; init; }

    [ForeignKey(nameof(ProjectId))]
    public ProjectEntity Project { get; init; } = default!;
  }
}
