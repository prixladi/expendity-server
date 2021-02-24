using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Http;

namespace Shamyr.Expendity.Server.Service.Configs
{
  public static class GraphQLConfig
  {
    public static PathString Endpoint => new PathString("/graphql");

    public static GraphQLPlaygroundOptions PlaygroundOptions => new GraphQLPlaygroundOptions
    {
      Path = "/ui/playground",
      SchemaPollingInterval = 50000
    };

    public static bool ExposeStackTrace
    {
      get
      {
        var expose = EnvVariable.TryGet(EnvVariables._GraphqlExposeStackTrace);
        if (bool.TryParse(expose, out var exp))
          return exp;

        return false;
      }
    }
  }
}
