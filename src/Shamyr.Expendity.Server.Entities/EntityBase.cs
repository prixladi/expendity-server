using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shamyr.Expendity.Server.Entities
{
  public class EntityBase<T>
  {
    public virtual T Id { get; init; } = default!;
  }

  public class EntityBase: EntityBase<int>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; init; } = default!;
  }
}
