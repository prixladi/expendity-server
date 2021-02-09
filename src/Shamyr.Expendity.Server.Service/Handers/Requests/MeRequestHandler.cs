using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shamyr.Cloud.Authority.Client.Services;
using Shamyr.Expendity.Server.Service.Models;
using Shamyr.Expendity.Server.Service.Requests;

namespace Shamyr.Expendity.Server.Service.Handers.Requests
{
  public class MeRequestHandler: IdentityRequestHandlerBase, IRequestHandler<MeRequest, MeModel>
  {
    private readonly IMapper fMapper;

    public MeRequestHandler(IClaimsIdentityService claimsIdentityService, IMapper mapper)
      : base(claimsIdentityService)
    {
      fMapper = mapper;
    }

    public Task<MeModel> Handle(MeRequest request, CancellationToken cancellationToken)
    {
      var identity = GetIdentity();
      var model = fMapper.Map<UserIdentity, MeModel>(identity);
      return Task.FromResult(model);
    }
  }
}
