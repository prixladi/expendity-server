﻿using System;

namespace Shamyr.Expendity.Server.Service.Dtos.Expense
{
  public class ExpenseDto
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public double Value { get; init; }
    public string? Description { get; init; }
    public DateTime AddedUtc { get; init; } 
    public int? TypeId { get; init; }
  }
}
