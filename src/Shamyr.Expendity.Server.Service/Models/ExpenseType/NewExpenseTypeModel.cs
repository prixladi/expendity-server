﻿namespace Shamyr.Expendity.Server.Service.Models.ExpenseType
{
  public class NewExpenseTypeModel
  {
    public string Name { get; init; } = default!;
    public string? Description { get; init; } 
    public int ProjectId { get; init; }
  }
}
