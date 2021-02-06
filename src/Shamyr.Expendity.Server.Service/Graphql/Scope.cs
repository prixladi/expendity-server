using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public sealed class Scope: IDisposable
  {
    private readonly IServiceScope fScope;

    public ISender Sender => fScope.ServiceProvider.GetRequiredService<ISender>();

    public Scope(IServiceProvider serviceProvider)
    {
      fScope = serviceProvider.CreateScope();
    }

    public void Dispose()
    {
      fScope.Dispose();
    }
  }
}
