using System;
using Microsoft.EntityFrameworkCore;

namespace Shamyr.Expendity.Server.Service.Configs
{
  public static class DbConfig
  {
    public static void SetupDatabase(DbContextOptionsBuilder options)
    {
      options
        .UseNpgsql(EnvVariable.Get(EnvVariables._DbConnectionString))
        .UseSnakeCaseNamingConvention();

#if DEBUG 
      options.LogTo(Console.WriteLine);
#endif
    }
  }
}
