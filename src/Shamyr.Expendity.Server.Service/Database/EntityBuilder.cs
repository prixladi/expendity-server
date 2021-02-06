using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Database
{
  public static class EntityBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      BuildByConvention(builder);

      builder
        .Entity<ExpenseEntity>()
        .HasOne(e => e.Type)
        .WithMany(e => e!.Expenses)
        .OnDelete(DeleteBehavior.SetNull);

     builder
        .Entity<ExpenseEntity>()
        .Property(e => e.AddedUtc)
        .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));
    }

    private static void BuildByConvention(ModelBuilder builder)
    {
      var types = typeof(EntityBase)
        .Assembly
        .GetExportedTypes()
        .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(EntityBase)))
        .ToArray();

      foreach (var type in types)
        builder.Entity(type);
    }
  }
}
