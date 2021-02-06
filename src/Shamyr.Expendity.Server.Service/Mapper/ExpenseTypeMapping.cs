using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.ExpenseType;
using Shamyr.Expendity.Server.Service.Models.ExpenseType;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class ExpenseTypeMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<ExpenseTypeEntity, ExpenseTypeDto>();
      exp.CreateMap<ExpenseTypeDto, ExpenseTypeModel>();
      exp.CreateMap<ExpenseTypeFilterModel, ExpenseTypeFilterDto>();

      exp.CreateMap<NewExpenseTypeModel, NewExpenseTypeDto>();
      exp.CreateMap<NewExpenseTypeDto, ExpenseTypeEntity>();
    }
  }
}
