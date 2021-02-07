﻿using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shamyr.Cloud.Authority.Client.Authentication;
using Shamyr.Expendity.Server.Service.Configs;
using Shamyr.Expendity.Server.Service.Database;
using Shamyr.Expendity.Server.Service.Factories;
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

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = AuthorityAuthenticationDefaults._AuthenticationScheme;
        options.DefaultChallengeScheme = AuthorityAuthenticationDefaults._AuthenticationScheme;
      })
      .AddAuthorityBearerAuthentication<AuthorityClientConfig, PrincipalFactory>();

      services.AddAuthorization();

      services.AddGraphQLSchema();

      services.AddServiceAssembly();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseGraphQL<ISchemaRoot>(GraphQLConfig.Endpoint);
      app.UseGraphQLPlayground(GraphQLConfig.PlaygroundOptions);
    }
  }
}
