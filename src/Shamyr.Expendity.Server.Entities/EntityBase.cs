using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shamyr.Expendity.Server.Entities
{
  public class EntityBase<T>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual T Id { get; init; } = default!;
  }

  public class EntityBase: EntityBase<int> { }
}
