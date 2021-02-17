using MediatR;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Models.Summary;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.Requests.Summary
{
  public class SummaryRequest: IProjectPermission, IRequest<SummaryModel>
  {
    public SummaryFilterModel Model { get; }

    int IProjectPermission.ProjectId => Model.ProjectId;
    PermissionType IProjectPermission.RequiredPermission => PermissionType.View;

    public SummaryRequest(SummaryFilterModel model)
    {
      Model = model;
    }
  }
}
