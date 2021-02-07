using System;
using AutoMapper;
using Shamyr.Expendity.Server.Entities;
using Shamyr.Expendity.Server.Service.Dtos.Expense;
using Shamyr.Expendity.Server.Service.Models.Expense;

namespace Shamyr.Expendity.Server.Service.Mapper
{
  public class ExpenseMapping: IMapping
  {
    public void Create(IMapperConfigurationExpression exp)
    {
      exp.CreateMap<ExpenseEntity, ExpenseDto>();
      exp.CreateMap<ExpenseDto, ExpenseModel>();

      exp.CreateMap<ExpenseFilterModel, ExpenseFilterDto>();

      exp.CreateMap<NewExpenseModel, NewExpenseDto>();
      exp.CreateMap<NewExpenseDto, ExpenseEntity>()
        .ForMember(e => e.AddedUtc, mc => mc.MapFrom(me => me.AddedUtc ?? DateTime.UtcNow));
    }
  }
}
