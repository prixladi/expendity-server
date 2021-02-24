using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Dtos.ProjectPermission;
using Shamyr.Expendity.Server.Service.Graphql.Exceptions;
using Shamyr.Expendity.Server.Service.Models.ProjectPermission;
using Shamyr.Expendity.Server.Service.Repositories;
using Shamyr.Expendity.Server.Service.Requests.ProjectInvite;
using Shamyr.Expendity.Server.Service.Services;

namespace Shamyr.Expendity.Server.Service.Handers.Requests.ProjectInvite
{
  public class AcceptProjectInviteRequestHandler: IdentityRequestHandlerBase, IRequestHandler<AcceptProjectInviteRequest, ProjectPermissionModel>
  {
    private readonly IProjectInviteRepository fProjectInviteRepository;
    private readonly IProjectPermissionRepository fProjectPermissionRepository;
    private readonly IDbTransactionService fDbTransactionService;
    private readonly IMapper fMapper;

    public AcceptProjectInviteRequestHandler(
      IProjectInviteRepository projectInviteRepository,
      IProjectPermissionRepository projectPermissionRepository,
      IDbTransactionService dbTransactionService,
      IClaimsIdentityService claimsIdentityService,
      IMapper mapper)
      : base(claimsIdentityService)
    {
      fProjectInviteRepository = projectInviteRepository;
      fProjectPermissionRepository = projectPermissionRepository;
      fDbTransactionService = dbTransactionService;
      fMapper = mapper;
    }

    public async Task<ProjectPermissionModel> Handle(AcceptProjectInviteRequest request, CancellationToken cancellationToken)
    {
      var identity = GetIdentity();

      // TODO: We don't handle scenario where user is already in project? Should we? or should FE handle it?
      var dto = await fDbTransactionService.InTransactionAsync(async () =>
      {
        var invite = await fProjectInviteRepository.GetByTokenAsync(request.Token, cancellationToken);
        if (invite is null)
          throw new NotFoundCodeException($"Project Invite with Token '{request.Token}' was not found.");

        var permission = await fProjectPermissionRepository.CreateOrUpdateAsync(
          invite.ProjectId, identity.Id, invite.ProjectPermissionType, cancellationToken);

        if (!invite.IsMultiUse)
          await fProjectInviteRepository.DeleteWithoutSelectAsync(invite.Id, cancellationToken);

        return permission;
      }, cancellationToken);

      // TODO: Find better solution instead of the AfterMap
      return fMapper.Map<ProjectPermissionDto, ProjectPermissionModel>(
        dto, opt => opt.AfterMap((_, model) => model.UserEmail = identity.Email));
    }
  }
}
