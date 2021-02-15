using Microsoft.AspNetCore.Hosting;
using Serilog;
using Shamyr.Expendity.Server.Service;
using Shamyr.Expendity.Server.Service.Configs;

await new WebHostBuilder()
  .UseKestrel()
  .UseSerilog(LoggingConfig.Setup)
  .UseStartup<Startup>()
  .Build()
  .RunAsync();
