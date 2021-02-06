using Microsoft.AspNetCore.Hosting;
using Shamyr.Expendity.Server.Service;

await new WebHostBuilder()
  .UseKestrel()
  .UseStartup<Startup>()
  .Build()
  .RunAsync();
