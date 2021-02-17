using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Shamyr.Expendity.Server.Service.ModelValidation;
using Shamyr.Expendity.Server.Service.PermissionValidation;

namespace Shamyr.Expendity.Server.Service.IoC
{
  public static class Mediator
  {
    public static void AddMediator(this IServiceCollection services)
    {
      services.AddTransient(typeof(IRequestPreProcessor<>), typeof(ModelValidationPipeline<>));
      services.AddTransient(typeof(IRequestPreProcessor<>), typeof(PermissionValidationPipeline<>));
      services.AddMediatR(typeof(Startup));
    }
  }
}
