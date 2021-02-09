using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Shamyr.Expendity.Server.Service.Graphql
{
  public class SchemaRoot: Schema, ISchemaRoot
  {
    public SchemaRoot(IServiceProvider services)
      : base(services)
    {
      Query = services.GetRequiredService<IQuery>();
      Mutation = services.GetRequiredService<IMutation>();
    }
  }
}
