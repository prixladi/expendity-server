using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Service.Database
{
  public class DatabaseContext: DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  optionsBuilder
    //    .UseSqlServer("Server=localhost;Database=Expendify;User Id=SA;Password=Pass@word1;")
    //    .UseSnakeCaseNamingConvention();
    //}

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      EntityBuilder.Build(builder);
    }
  }
}
