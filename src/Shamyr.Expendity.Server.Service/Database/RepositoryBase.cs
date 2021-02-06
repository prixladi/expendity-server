using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Database
{
  public abstract class RepositoryBase<TEntity, T>
    where TEntity : EntityBase<T>
  {
    protected DatabaseContext Context { get; }

    protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

    protected IMapper Mapper { get; }

    protected RepositoryBase(DatabaseContext context, IMapper mapper)
    {
      Context = context;
      Mapper = mapper;
    }
  }

  public abstract class RepositoryBase<TEntity>: RepositoryBase<TEntity, int>
    where TEntity : EntityBase
  {
    protected RepositoryBase(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }
  }
}
