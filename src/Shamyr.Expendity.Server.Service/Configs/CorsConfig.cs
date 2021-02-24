using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Shamyr.Expendity.Server.Service.Configs
{
  public static class CorsConfig
  {
    public static void Setup(CorsPolicyBuilder builder)
    {
      builder.AllowAnyOrigin();
      builder.AllowAnyHeader();
      builder.AllowAnyMethod();
    }
  }
}
