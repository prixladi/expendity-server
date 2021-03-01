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
      exp.CreateMap<ExpenseEntity, ExpenseDto>()
        .ForMember(d => d.CreatorUserEmail, me => me.MapFrom(e => e.CreatorUser.Email))
        .ForMember(d => d.LastUpdaterUserEmail, me => me.MapFrom(e => e.LastUpdaterUser == null ? null : e.LastUpdaterUser.Email));

      exp.CreateMap<ExpenseDto, ExpenseModel>();

      exp.CreateMap<ExpenseFilterModel, ExpenseFilterDto>();

      exp.CreateMap<CreateExpenseModel, CreateExpenseDto>();
      exp.CreateMap<UpdateExpenseModel, UpdateExpenseDto>();

      exp.CreateMap<CreateExpenseDto, ExpenseEntity>()
        .ForMember(e => e.DateAdded, mc => mc.MapFrom(me => me.DateAdded));

      exp.CreateMap<UpdateExpenseDto, ExpenseEntity>()
        .ForMember(e => e.DateAdded, mc => mc.MapFrom(me => me.DateAdded));
    }
  }
}
