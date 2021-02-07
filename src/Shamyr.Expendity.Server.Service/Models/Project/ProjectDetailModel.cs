using System;
using System.Collections.Generic;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class ProjectDetailModel: ProjectModel
  {
    public ICollection<ProjectPermissionModel> Permissions { get; init; } = Array.Empty<ProjectPermissionModel>();
    public ICollection<ExpenseTypeModel> ExpenseTypes { get; init; } = Array.Empty<ExpenseTypeModel>();
  }
}
