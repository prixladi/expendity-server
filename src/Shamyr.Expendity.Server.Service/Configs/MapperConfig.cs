using System;
using System.Linq;
using AutoMapper;
using Shamyr.Expendity.Server.Service.Mapper;

namespace Shamyr.Expendity.Server.Service.Configs
{
  public static class MapperConfig
  {
    public static void Configure(IMapperConfigurationExpression exp)
    {
      var mappingType = typeof(IMapping);
      var mappings = mappingType.Assembly.GetExportedTypes()
        .Where(type => !type.IsAbstract && mappingType.IsAssignableFrom(type))
        .Select(Activator.CreateInstance)
        .Cast<IMapping>()
        .ToArray();

      foreach (var mapping in mappings)
        mapping.Create(exp);
    }
  }
}
