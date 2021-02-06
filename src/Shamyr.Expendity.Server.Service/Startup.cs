using AutoMapper;
using GraphQL.Server.Ui.Playground;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shamyr.Expendity.Server.Service.Configs;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Graphql;
using Shamyr.Expendity.Server.Service.IoC;

namespace Shamyr.Expendity.Server.Service
{
  public sealed class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DatabaseContext>(DbConfig.SetupDatabase);

      services.AddApplicationInsights(ApplicationInsightsConfig.Setup);
      services.AddHttpContextAccessor();
      
      services.AddAutoMapper(MapperConfig.Configure, typeof(Startup));
      services.AddMediatR(typeof(Startup));

      services.AddGraphQLSchema();

      services.AddServiceAssembly();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseGraphQL<ISchemaRoot>("/graphql");
      app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { Path = "/ui/playground" });
    }
  }
}
