﻿using System;
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

      builder.Entity<ExpenseEntity>()
        .HasOne(e => e.Type)
        .WithMany(e => e!.Expenses)
        .OnDelete(DeleteBehavior.SetNull);

      builder.Entity<ExpenseEntity>()
         .Property(e => e.DateAdded)
         .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

      builder.Entity<ExpenseEntity>()
        .HasOne(e => e.CreatorUser)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);

      builder.Entity<ExpenseEntity>()
        .HasOne(e => e.LastUpdaterUser)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);
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
